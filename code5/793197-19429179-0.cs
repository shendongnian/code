    public partial class Home : System.Web.UI.Page
    {
        protectedList<string> emp;
      protected void Page_Load(object sender, EventArgs e)
      {
        emp = new List<string>();
        emp.Add("xxxx");
        emp.Add("yyy");
      }
    }
