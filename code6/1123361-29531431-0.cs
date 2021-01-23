    private void PivotGridControl_DataSourceChanged(object sender, RoutedEventArgs e)
    {
        var pivotTable = sender as PivotGridControl;
        pivotTable.Groups.Clear();
        pivotTable.RetrieveFields();
        var dateTimeFields = pivotTable.Fields.Where(item => item.DataType == typeof(DateTime)).ToList();
        foreach (var field in dateTimeFields)
        {
            var group = new PivotGridGroup();
            group.Add(new PivotGridField() { FieldName = field.FieldName, Caption = field.Caption + " (year)", GroupInterval = FieldGroupInterval.DateYear });
            group.Add(new PivotGridField() { FieldName = field.FieldName, Caption = field.Caption + " (month)", GroupInterval = FieldGroupInterval.DateMonth });
            group.Add(new PivotGridField() { FieldName = field.FieldName, Caption = field.Caption + " (day)", GroupInterval = FieldGroupInterval.DateDay });
            foreach (var groupField in group)
                pivotTable.Fields.Add(groupField);
            pivotTable.Groups.Add(group);
        }
    }
