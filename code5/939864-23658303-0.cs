        protected void Page_Load(object sender, EventArgs e)
        {
             // Check if user is logged in, and return JSON result of search
             if (User.Identity.IsAuthenticated)
             {
                 string json = MySearch(Request["Search"], Session["Language"]);
                 Response.Clear();
                 Response.ContentType = "application/json; charset=utf-8";
                 Response.Write(json);
                 Response.End();
             }
       }
