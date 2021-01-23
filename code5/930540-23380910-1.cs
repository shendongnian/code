    public partial class FooBar : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptFoos.DataSource = Service.GetFoos();
            rptFoos.DataBind();
        }
    }
