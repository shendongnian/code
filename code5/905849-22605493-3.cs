    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        public string GetDataFromControls()
        {
            return TextBox1.Text;
        }
    }
