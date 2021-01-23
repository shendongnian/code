    DataTable dataTable = new DataTable("Country");
    dataTable.Columns.Add("Id");
    dataTable.Columns.Add("Name");
    dataTable.Rows.Add(45, "Denmark");
    dataTable.Rows.Add(63, "Philippines");
    
    comboBox1.DataSource = dataTable;
    comboBox1.DisplayMember = "Name";
    comboBox1.ValueMember = "Id";
    
    comboBox1.SelectedIndex = 1;
    comboBox1.Refresh();
    
    DataRow selectedDataRow = ((DataRowView)comboBox1.SelectedItem).Row;
    int countryId = Convert.ToInt32(selectedDataRow["Id"]);
    string countryName = selectedDataRow["Name"].ToString();
    
    int selectedValue = Convert.ToInt32(comboBox1.SelectedValue);
