    //master page code behind
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    //test method
    public void test()
    {
    }
    }
    //content page code behind
    public partial class About : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteMaster master = new SiteMaster();
        master.test();
    }
    }
