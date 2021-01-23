    private void dg_AutoGeneratingColumn(object sender,
                                         DataGridAutoGeneratingColumnEventArgs e)
    {
        DataGridTextColumn textColumn = (DataGridTextColumn)e.Column;
        var propertyPath = ((Binding)textColumn.Binding).Path.Path;
        // propertyPath will be Credit Spreads-GBP-0.25-AAA in your case.
    }
