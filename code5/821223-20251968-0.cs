    using System;
    using System.Windows.Forms;
    
    namespace SampleBrowserautomate
    {
        public partial class Form1 : Form
        {
            // first of all, insert web browser control and button control into your form
            string target = "https://www.facebook.com/login.php";
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void btnGo_Click(object sender, EventArgs e)
            {
                webBrowser1.Navigate(target);
            }
    
            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                WebBrowser b = (WebBrowser)sender;
                b.Document.GetElementById("email").InnerText = "helloworld@gmail.com";
                b.Document.GetElementById("pass").InnerText = "HelloWorld";
                b.Document.GetElementById("u_0_1").InvokeMember("click");
            }
        }
    }
