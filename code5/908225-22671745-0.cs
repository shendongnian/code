    public partial class _Default : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void textbox_TextChanged(object sender, EventArgs e)
        {
	        int total;        
            total = int.Parse(this.TextBox1.Text) + int.Parse(this.TextBox2.Text);
            Label1.Text = total.ToString();
        }
    }
