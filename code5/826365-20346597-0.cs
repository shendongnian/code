    public partial class TestPartial : System.Web.UI.Page
    {    
        partial void Test(); // add this line
    
        protected void Page_Load(object sender, EventArgs e)
        {
            Test();
        }
    }
    
    
    public partial class TestPartial : System.Web.UI.Page
    {
        partial void Test()  
        {
             // executed from Page_Load
        }
    }
