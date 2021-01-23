    public partial class Test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ucTest.TextApplied += new EventHandler(ucTest_TextApplied);
            
        }
        protected void ucTest_TextApplied(Object sender, EventArgs e)
        {
            lbl1.Text = ucTest.Text;
            
        }
    }
