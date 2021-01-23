        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindGrid(); // Bind the grid here
            // After reloading the page you flush the file
            if (Session["FILE"] != null)
                FlushFile();
        }
        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Generate & Save PDF here
            Session["FILE"] = fullFilePath; // The full path of the file you saved.
            Response.Redirect(Request.RawUrl); // This reload the page
        }
        private void FlushFile()
        {
            string fullFilePath = Session["FILE"].ToString();
            Session["FILE"] = null; 
            // Flush file here
        }
