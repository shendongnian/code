    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["ID"]!= null )
            {
                lblmsg.Text = "You are loged in";
            }
        }
    
        Dictionary<string, string> db = new Dictionary<string, string>(){
            {"Ali","XXX"},
            {"Alex","YYY"},
            {"Mina","zzz"},
            {"Admin","123"}
        };
        protected void Button1_Click(object sender, EventArgs e)
        {
           //simulating your database search
            if (db.Contains(new KeyValuePair<string,string>( txtBoxUser.Text,txtBoxPassword.Text)))
            {
                HttpContext.Current.Session["ID"] = txtBoxUser.Text;            
            }else
    	    {
                lblmsg.Text = "Not Logged in ";
    	    }
        }
