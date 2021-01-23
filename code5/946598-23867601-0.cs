    public partial class _Default : System.Web.UI.Page 
    {
        int num;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                num = 1;
                Session["number"] = num;
                Label_PageNumber.Text = "Page0" + num.ToString();
            }
            else
            {
                num = (int)Session["number"];
            }      
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            num++;
            Session["number"] = num;
            Label_PageNumber.Text = "Page0" + num.ToString();
        }
    }
