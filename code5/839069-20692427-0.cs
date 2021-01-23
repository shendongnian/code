    public partial class WebUserControl : System.Web.UI.UserControl
    {
        public string MyText
        {
            get { return MyTextBox.Text; }
            set { MyTextBox.Text = value; }
        }
    }
