    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Image i = new Image();
            i.ImageUrl = "ImageFeeder.ashx";
    
            form1.Controls.Add(i);
            
        }
    }
