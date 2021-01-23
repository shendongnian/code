    string[][] array = fs.CSVToStringArray();
    for (int i = 0; i < array[0].Length; i++)
    {
    	var col = new DataGridTextColumn();
    	col.Header = "Column " + i;
    	col.Binding = new Binding(string.Format("[{0}]", i));
    	_dataGrid.Columns.Add(col);
    }
    this.ExternalData._dataGrid.ItemsSource = array;
