    void DataLoaded(object sender, EventArgs e)
    {
        if (this.IsActive)
        {                
            grid.Focus();
            grid.SelectedIndex = 0;
        }
    }
