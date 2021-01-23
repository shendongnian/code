    namespace myNamespace
    {
        public partial class functions : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            [WebMethod()]
            public static string doSomething(string Id)
            {
                string something = "Hello World!";
                return something;
            }
        }
    }
