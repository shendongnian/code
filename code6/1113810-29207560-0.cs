    public class CommonPage: Page
    {
        public CommonPage()
        {
            this.Load += Page_Load;
        }
        private void Page_Load
        {
            Session["prevUrl"] = Request.Url;
        }
    }
