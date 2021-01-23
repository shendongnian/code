    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddListTest.ClearSelection();
            ddListTest.Items.FindByValue("item2").Selected = true;
        }
    }
