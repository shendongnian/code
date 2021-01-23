    private static void TotalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((TotalsDataGridCellContentControl)d).EvaluateCondition();
    }
    private static void ConditionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((TotalsDataGridCellContentControl)d).EvaluateCondition();
    }
