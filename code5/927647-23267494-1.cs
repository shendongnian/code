    protected void ddlMonth_DataBinding(object sender, System.EventArgs e)
    {
        DropDownList ddl = (DropDownList)(sender);
        for (int i = 1; i <= 12; i++)
            {
                DateTime date = new DateTime(1900, i, 1);
                ddl.Items.Add(newSystem.Web.UI.WebControls.ListItem(date.ToString("MMMM"), i.ToString()));
            }
    }
    protected void ddlYear_DataBinding(object sender, System.EventArgs e)
    {
        DropDownList ddl = (DropDownList)(sender);
        var currentYear = DateTime.Now;
        for (int i = 1900; i <= Convert.ToInt32(currentYear.ToString("yyyy")); i++)
        {
            ddl.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString()));
        }   
    }
