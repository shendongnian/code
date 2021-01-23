    private void admin()
        {
            if (Session["UserName"].ToString() == "admin")
            {
                this.Master.FindControl("abc").Visible = true;
            }
        }
