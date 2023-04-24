using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using ZXing.Rendering;
using Bytescout.BarCode;
using static QRCoder.PayloadGenerator;


namespace Create_a_QR_Code_vCard_and_Logo
{
    public partial class Form1 : Form
    {

        public static string payload;
        public QrCodeEncodingOptions _options;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



            txtfirstname.Text ="Saddam ";
            txtlastname.Text = "Hussein ";  
            txtnickname.Text = "Saddam Hussein";
            txtphone.Text = "+9671582207";
            txtmobilePhone.Text = "+967777908008";
            txtworkPhone.Text = "+9671450121";
            txtemail.Text = "saddamalsalfi@qau.edu.ye";
            txtwebsite.Text = "https://qau.edu.ye/";
            txtstreet.Text = "60th";
            txthouseNumber.Text = "Alanab";
            txtcity.Text = "Sanaa City";
            txtzipCode.Text = "00000";
            txtcountry.Text = "YEMEN";
            txtnote.Text = "CS & IT ENGINEER";
            txtstateRegion.Text = "Sanaa";
            txtorg.Text = "Queen Arwa University";
            txtorgTitle.Text = "Devloper";




            _options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 750,
                Height = 750,
            };
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = _options;


            genertorVcard();


        }



        public string genertorVcard()
        {




            ContactData generator = new ContactData(ContactData.ContactOutputType.VCard3, txtfirstname.Text
            , txtlastname.Text, txtnickname.Text,  txtphone.Text, txtmobilePhone.Text,
             txtworkPhone.Text, txtemail.Text, null, txtwebsite.Text, txtstreet.Text,
              txthouseNumber.Text, txtcity.Text, txtzipCode.Text, txtcountry.Text, txtnote.Text,
              txtstateRegion.Text, ContactData.AddressOrder.Default, txtorg.Text, txtorgTitle.Text);
            payload = generator.ToString();


            return payload;

        }





        public void QrVCardGenerator()
        {
            /*
           .
            
         firstname
         lastname
         nickname
         org
         orgTitle
         phone
         mobilePhone
         workPhone
         email
         birthday
         website
         street
         houseNumber
         city
         zipCode
         stateRegion
         country
         note
         outputType
         addressOrder;




             */





            

            BarcodeWriter barcodeWriter = new BarcodeWriter();
           EncodingOptions encodingOptions = new EncodingOptions() { Width = 750, Height = 750, Margin = 0, PureBarcode = false };
            barcodeWriter.Options = _options;
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);    
            barcodeWriter.Renderer = new BitmapRenderer();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap _bitmap = barcodeWriter.Write(payload.Trim());
            Bitmap logo = new Bitmap($"{Application.StartupPath}/qaulogo.png");
            Graphics graph1 = Graphics.FromImage(_bitmap);
            graph1.DrawImage(logo, new Point((_bitmap.Width - logo.Width) / 2, (_bitmap.Height - logo.Height) / 2));


            pictureBox1.Image = _bitmap;
        



        }





        private void button1_Click(object sender, EventArgs e)
        {


            QrVCardGenerator();


        }
    }
}
