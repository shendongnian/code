    TextBox txt = (TextBox)sender;
    float value = float.Parse(txt.Text);
    GridViewRow row = (GridViewRow)txt.NamingContainer;
    GridView gridView = (GridView)row.NamingContainer;
    float total = gridView.Rows.Cast<GridViewRow>()
        .Sum(r => float.Parse(((TextBox)txt.FindControl("txtbox")).Text));
