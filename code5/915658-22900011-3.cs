    foreach (String colour in ColourSwatches)
    {
        TableRow Row = new TableRow();
        Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + colour);
        Row.ToolTip = "mycolor";
        table.rows.Add(row);
    }
