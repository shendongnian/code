    var allCheckBoxes = e.Row.Cells.Cast<DataControlFieldCell>()
        .SelectMany(c => c.Controls.OfType<CheckBox>());
    foreach (CheckBox cb in allCheckBoxes)
    {
        cb.Attributes.Add("onclick", "javascript:SelectAll(this);");
    }
