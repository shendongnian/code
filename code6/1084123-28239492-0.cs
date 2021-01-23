        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UserName"] as string))
            {
                admin();
            }
        }
        private void admin()
        {
            if (Session["UserName"].ToString() == "admin")
            {
                this.Page.FindControl("abc").Visible = true;
            }
        }
