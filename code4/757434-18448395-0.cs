    MyEntityModel entity = new MyEntityModel();
    
    private void LoadData<T>(DataGrid dataGrid)
        where T : class
    {    
        dataGrid.ItemsSource = entity.Set<T>().ToList();
    }
