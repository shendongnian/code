    public partial class Test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = ComboBox1.SelectedValue.ToString();
        }
    }
