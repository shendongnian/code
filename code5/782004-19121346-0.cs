    private DataTable dataForDisplay;
    // This would be overridden by all child classes, adding their columns in the order you want
    public virtual DataTable GetDataForDisplay()
    {
        dataForDisplay = new DataTable();
        dataForDisplay.Columns.Add("ID");
        dataForDisplay.Columns.Add("Name");
        // If you want to change the order, just don't call the base.GetDataForDisplay()
        dataForDisplay.Rows.AddRange(this.ID, this.Name);
        return dataForDisplay;
    }
