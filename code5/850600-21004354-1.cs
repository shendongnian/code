    public partial class addition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            double userValue = 0;
            if (double.TryParse(TextBox1.Text,out userValue))
            {
                Label1.Text = (double.Parse(Label1.Text) + userValue).ToString();
            }
        }
    }
