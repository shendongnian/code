    private void FormLoad(object sender, EventArgs e)
    {
        // I assume that Entity is a variable of type Table2, 
        // if not then change Table2 to any other class
        Source = new BindingSource(typeof(Table2), null);
   
        txtItemId.DataBindings.Add("Value", Source, "ItemId", true, DataSourceUpdateMode.OnPropertyChanged);
        txtItemName.DataBindings.Add("Text", Source, "ItemName", true, DataSourceUpdateMode.OnPropertyChanged);
    }
