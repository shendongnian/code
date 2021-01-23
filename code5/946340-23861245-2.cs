    int check = 0;
    foreach (RepeaterItem itemm in searchResultRepeater.Items)
    {
        for (int i = 0; i < itemm.Controls.Count; i++)
        {
            Control ctrl = itemm.Controls[i];
            // use as to safely cast will be null if can't convert
            var tb = ctrl as TextBox;
            var ddl = ctrl as DropDownList;
            if ((tb != null && tb.Text != null && tb.Text.Length > 0) ||
                (ddl != null && ddl.Text != null && ddl.Text.Length > 0))
            {
                check = 1;
                break;
            }
        }
    }
