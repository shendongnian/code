    class MyDataGrid : DataGrid
    {
        static MyDataGrid()
        {
            DataGrid.DataContextProperty.OverrideMetadata(typeof(MyDataGrid),
                new FrameworkPropertyMetadata(null, 
                    FrameworkPropertyMetadataOptions.Inherits,
                    new PropertyChangedCallback(OnDataContextChanged)));
        }
    }
