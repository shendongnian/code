    using System;
    using System.IO;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       private void EncryptFile()
        {            
    var file = new FileInfo("C:\Users\Mateen\Downloads\MyImage.jpg");
    byte[] ImageBytes;
    using(var stream = file.OpenRead()) {
       ImageBytes=  = new byte[stream.Length];
       stream.Read(ImageBytes,0,(int)stream.Length);
    }
                for (int i = 0; i < ImageBytes.Length; i++)
                {
                    ImageBytes[i] = (byte)(ImageBytes[i] + 5);
                }
                //do something with your encrypted image here.
                      
        }
        private void DecryptFile()
        {
    var file = new FileInfo("C:\Users\Mateen\Downloads\MyImage.jpg");
    byte[] ImageBytes;
    using(var stream = file.OpenRead()) {
       ImageBytes=  = new byte[stream.Length];
       stream.Read(ImageBytes,0,(int)stream.Length);
    }
                for (int i = 0; i < ImageBytes.Length; i++)
                {
                    ImageBytes[i] = (byte)(ImageBytes[i] - 5);
                }
                //Do something here
                      
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           Encrypt()
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           Decrypt()
        }
    }
}
