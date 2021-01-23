    void DataLoaded(object sender, EventArgs e)
    {
        var window = this.GetParent<Window>();
        if (window.IsActive)
        {         
            var grid = this.GetChild<DataGrid>();
            grid.Focus();
        }
    }
