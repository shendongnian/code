    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["Incrementer"] == null)
            {
                Session["Incrementer"] = "1";
            }
            else
            {
                int incrementer = Convert.ToInt32(Session["incrementer"].ToString()) + 1;
                Session["incrementer"] = incrementer.ToString();
            }
            Label1.Text = Session["incrementer"].ToString();
        }
    }
