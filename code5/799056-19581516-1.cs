    try this:
    protected void listboxuserteamleader_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in gvusers.Rows)
        {
            TextBox txtuserteamleader = (TextBox)gvr.FindControl("txtuserteamleader");
            ListBox listboxuserteamleader = (ListBox)gvr.FindControl("listboxuserteamleader");
            txtuserteamleader.Text = listboxuserteamleader.SelectedValue.ToString();
        }
    }
