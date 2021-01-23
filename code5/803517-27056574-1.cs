    protected void btnLogout_Click(object sender, EventArgs e)
            {
                Session.RemoveAll();
                Response.Redirect("~/Login.aspx");
                ...
            } 
