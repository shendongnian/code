    public partial class WebUserControl1 : System.Web.UI.UserControl, IMyUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListBox1.SelectedIndexChanged += (o, args) =>
            {
                var selectedIndexChanged = SelectedIndexChanged;
                if (selectedIndexChanged != null)
                    selectedIndexChanged(o, args);
            };
        }
    
        public event EventHandler SelectedIndexChanged;
    }
