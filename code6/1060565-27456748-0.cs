    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var tempList = new List<object>();
            tempList.Add(new { Title = "test" });
            Repeater1.DataSource = tempList;
            Repeater1.DataBind();
        }
    }
