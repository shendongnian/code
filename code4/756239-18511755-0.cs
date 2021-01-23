    public partial class SubDirectory_my : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My_ChildMasterPage hideMySideBar = this.Master;
            hideMySideBar.HideSideBar();
        }
