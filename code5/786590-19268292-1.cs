    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label_TESTDICT.Text = "";
            List<String> keys = Global.TEST_DICT.Keys.ToList();
            foreach (String key in keys)
            {
                Label_TESTDICT.Text += key + ":" + Global.TEST_DICT[key] + "<br>"; 
            }
        }
    }
