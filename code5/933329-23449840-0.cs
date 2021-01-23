    private void myDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
    	if (e.PropertyName == "Sections")
    	{
    		var cb = new DataGridComboBoxColumn();
    		cb.Header = "Sections";
    		cb.ItemsSource = new List<string> { "C50", "C40", "C30" };
    		cb.SelectedValueBinding = new Binding("Sections");
    		e.Column = cb;
    	}        
    }
