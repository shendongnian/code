    DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)GridSellProducts.Columns["Item"];
    foreach (string productname in productNames)
    {
    	column.Items.Add(productname);
    }
    this.ValueType = typeof(string);
    // if you use a custom object instead of a string, set these values:
    // this.DisplayMember = "value";
    // this.ValueMember = "hiddenValue";
