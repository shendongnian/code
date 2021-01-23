    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
     
        [WebMethod]
        public static string Name()
        {
            string Name = "Hello Stack";
            return Name;
        }
    }
