    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadFile("http://localhost:61579/ImageFeeder.ashx", Path.Combine(Server.MapPath("."), "myimage.png"));
        }
    }
