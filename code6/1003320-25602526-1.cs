    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           BLMethods objBLMethods = new BLMethods(GridView1);
           objBLMethods.BindingDataToControls();
        }
    
    }
