        protected void chckOnCheckedChange(object sender, EventArgs e)
        {
            if (clsSessionManager.GetInstance().SUICulture== "es")
            {
                clsSessionManager.GetInstance().SUICulture= "en";
            }else
            {
                clsSessionManager.GetInstance().SUICulture= "es";
            }
            Response.Redirect(Page.Request.Url.ToString(), true);
        }
