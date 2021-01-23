    public partial class Default : System.Web.UI.Page
    {
        public List<string> Values = new List<string>() { "CHK 1", "CHK 2", "CHK 3", "CHK 4" };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
            chksOne.DataSource = Values;
            chksOne.DataBind();
            //EXTENSION METHOD DEFINED ABOVE
            chksOne.CheckItemsFromCookie("CBL");
        }
        protected void chksOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxList list = sender as CheckBoxList;
            if(list == null)
                return;
            //EXTENSION METHOD DECLARED IN CLASS EXTENSIONS ABOVE
            list.SaveValuesToCookie("CBL");
        }
    }
