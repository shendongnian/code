    using System;
    using System.Windows.Forms;
    
    namespace winformWebBrowser
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                webBrowser1.Navigate("http://localhost:4542");
                webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
            }
    
            void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                webBrowser1.Document.AttachEventHandler("foo", new EventHandler(delegate(object s, EventArgs k)
                {
                    MessageBox.Show("foo");
                    
                }));
            }
        }
    }
