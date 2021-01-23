    namespace MyProject
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    bool is_sec_page = false;
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           if (!is_sec_page)
               { 
              HtmlDocument doc = webBrowser1.Document;
              HtmlElement username = doc.GetElementById("UserName");
              HtmlElement password = doc.GetElementById("Password");
              HtmlElement submit = doc.GetElementById("submit");
              username.SetAttribute("value", "XXXXXXXX");
              password.SetAttribute("value", "YYYYYYYYYY");
              submit.InvokeMember("click");
             is_sec_page = true;
           }
               else
                {
                    //intract with sec page elements with theire ids and so on
                }
    
        }
      }
    }
