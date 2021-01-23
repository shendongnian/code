     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // to check page is post back or not
            {
                // do stuff here
                
            }
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")  // this is to check whether it's an AJAX call or not
            {
                // do stuff here..
            }
        }
        [System.Web.Services.WebMethod]
        public static bool changeLanguage(string languageIdentifier)
        {
            // do logic here....
            return true;
        }
