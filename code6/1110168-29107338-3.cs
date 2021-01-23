    List<Color> allAvailableColorOptions = new List<Color>();
    // add all the possible colors to this list.
    var colorSelectColumn = new DataGridViewComboBoxColumn(); 
    colorSelectColumn.DataPropertyName = "ColorOptions";   
    colorSelectColumn.DisplayMember = "Label";
    colorSelectColumn.ValueMember = "Id";
    colorSelectColumn.DataSource = allAvailableColorOptions;
    
