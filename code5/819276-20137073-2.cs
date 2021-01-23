    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        public string myTest { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            myLabel.InnerText = myTest;
        }
    }
