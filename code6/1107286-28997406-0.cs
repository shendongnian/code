    protected void Button1_Click(object sender, EventArgs e)
        {
        var test = new List<string>();
        foreach (ListItem item in CheckBoxList1.Items)
        {
            if (item.Selected)
            {
                // oneSelected = true;
                test.Add(item.Value);
                Response.Write("<script LANGUAGE='JavaScript' >alert('"+item.Value+"')</script>");
            }
        }
     }  
