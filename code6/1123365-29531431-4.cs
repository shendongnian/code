    private void PivotGridControl_DataSourceChanged(object sender, RoutedEventArgs e)
    {
        var pivotTable = sender as PivotGridControl;
        pivotTable.RetrieveFields();
        var dateTimeFields = pivotTable.Fields.Where(item => item.DataType == typeof(DateTime)).ToList();
        foreach (var field in dateTimeFields)
        {
            var fieldYear = new PivotGridField()
            {
                FieldName = field.FieldName,
                Caption = field.Caption + " (year)",
                GroupInterval = FieldGroupInterval.DateYear,
                Visible = false,
                DisplayFolder = field.Caption
            };
            var fieldMonth = new PivotGridField()
            {
                FieldName = field.FieldName,
                Caption = field.Caption + " (month)",
                GroupInterval = FieldGroupInterval.DateMonth,
                Visible = false,
                DisplayFolder = field.Caption
            };
            var fieldDay = new PivotGridField()
            {
                FieldName = field.FieldName,
                Caption = field.Caption + " (day)",
                GroupInterval = FieldGroupInterval.DateDay,
                Visible = false,
                DisplayFolder = field.Caption
            };
            pivotTable.Fields.Add(fieldYear);
            pivotTable.Fields.Add(fieldMonth);
            pivotTable.Fields.Add(fieldDay);
        }
    }
