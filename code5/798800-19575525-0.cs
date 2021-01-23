    static ExtendedDataGrid()
    {
        SelectionModeProperty.OverrideMetadata(typeof(ExtendedDataGrid), 
            new FrameworkPropertyMetadata(SelectionMode.Extended));
    }
