    private int _selectedSum;
    private string _fieldName = "TOPLAM";
    private void Form1_Load(object sender, EventArgs e)
    {
        var column = gridView1.Columns[_fieldName];
        column.SummaryItem.SummaryType = SummaryItemType.Custom;
    }
    private void gridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var column = gridView1.Columns[_fieldName];
        switch (e.Action)
        {
            case CollectionChangeAction.Add:
                _selectedSum += (int)gridView1.GetRowCellValue(e.ControllerRow, column);
                break;
            case CollectionChangeAction.Remove:
                _selectedSum -= (int)gridView1.GetRowCellValue(e.ControllerRow, column);
                break;
            case CollectionChangeAction.Refresh:
                _selectedSum = 0;
                foreach (var rowHandle in gridView1.GetSelectedRows())
                    _selectedSum += (int)gridView1.GetRowCellValue(rowHandle, column);
                break;
        }
        gridView1.UpdateTotalSummary();
    }
    private void gridView1_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
    {
        var item = e.Item as GridColumnSummaryItem;
        if (item == null || item.FieldName != _fieldName)
            return;
        if (e.SummaryProcess == CustomSummaryProcess.Finalize)
            e.TotalValue = _selectedSum;
    }
