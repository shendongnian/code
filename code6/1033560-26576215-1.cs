    protected void Button1_Click(object sender, EventArgs e)
    {
        List<string> selected = CheckBoxList1.Items.Cast<ListItem>()
            .Where(li => li.Selected)
            .Select(li => li.Text)
            .ToList();
        string sel = string.Join(",", selected);
        Response.Redirect("Second.aspx?cols=" + sel);
    }
