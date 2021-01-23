    public partial class p : System.Web.UI.Page
    {
        private int? GetX()
        {
            return // some helper method will return the value of X;
        }
    }   
    protected void Page_Load(object sender, EventArgs e)
    {
      // in the page load event
       var d = GetX();
    }
