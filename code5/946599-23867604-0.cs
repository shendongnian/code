    public partial class Form : System.Web.UI.Page
    {
     static int num = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label_PageNumber.Text = "Page0" + num.ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        num++;
        Label_PageNumber.Text = "Page0" + num.ToString();
    }
}
