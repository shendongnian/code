    protected void Button1_Click(object sender, EventArgs e)
    {
        List<string> daysrequested = new List<string>();
        
        foreach (ListItem daysItem in Checkboxlist1.Items)
        {
            if (daysItem.Selected)
            {
                daysrequested.Add(daysItem.Value);
            }
        }
        Session["daysre"] = daysrequested;
        Response.Redirect("Page2.aspx");
    }
