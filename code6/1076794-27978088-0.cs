    protected void RedirectToLink_SelectedIndexChnaged(object sender, EventArgs e)
    {
        if (ddlOtherWebsites.SelectedIndex != -1)
        {
            DataTable dt = db.getDataTable("select * from otherwebsites where Status='1' and id=" + ddlOtherWebsites.SelectedValue.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + dt.Rows[0]["shortdescp"].ToString() + "','_blank');",true);
            }
        }
    }
