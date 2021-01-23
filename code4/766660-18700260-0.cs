    void payloadDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        string tooltip = null;
            
        switch (e.Column.Header.ToString())
        {
            case "Column 1":
                tooltip = "Tooltip 1";
                break;
            case "Column 2":
                tooltip = "Tooltip 2";
                break;
        }
        if (tooltip != null)
        {
            var style = new Style(typeof(DataGridCell));
            style.Setters.Add(new Setter(ToolTipService.ToolTipProperty, tooltip));
            e.Column.CellStyle = style;
        }
    }
