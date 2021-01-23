    protected void Page_Load(object sender, EventArgs e)
        {
             pivotGrid.RetrieveFields();
             pivotGrid.Fields["YEAR"].Area = PivotArea.ColumnArea;
             pivotGrid.Fields["YEAR"].GroupInterval = PivotGroupInterval.DateYear;
             pivotGrid.Fields["MONTH"].Area = PivotArea.ColumnArea;
             pivotGrid.Fields["MONTH"].GroupInterval = PivotGroupInterval.Custom;
             pivotGrid.Fields["MONTH"].SortMode = PivotSortMode.Custom;
        }
    private void pivotGrid_CustomGroupInterval(object sender, PivotCustomGroupIntervalEventArgs e)
       {
             e.GroupValue = ((DateTime)e.Value).ToString("MMM");
       }
    private void pivotGrid_CustomFieldSort(object sender, PivotGridCustomFieldSortEventArgs e)
    {
        if (e.Field.FieldName == "MONTH")
        {
                    if (e.Value1 == null || e.Value2 == null) return;
                    e.Handled = true;
                    DateTime d1 = Convert.ToDateTime("1 " + e.Value1.ToString() + " 1900");
                    DateTime d2 = Convert.ToDateTime("1 " + e.Value2.ToString() + " 1900");
                    if (d1 > d2)
                        e.Result = 1;
                    else if (d1 == d2)
                        e.Result = 0;
                    else
                        e.Result = -1;
        }
    }
