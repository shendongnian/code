    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            user.username = TextBox1.Text;
            if (Cache["userList"] == null)
                Cache["userList"] = new ArrayList();
            ((ArrayList)Cache["userList"]).Add(user);
            foreach (User u in (ArrayList)Cache["userList"])
            {
                ListBox1.Items.Add(String.Format(u.username));
            }
        }
    }
