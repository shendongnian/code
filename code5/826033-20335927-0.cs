    DataSet1.titlesDataTable TitlesTable = new DataSet1.titlesDataTable();
    
    titlesTableAdapter1.Fill(TitlesTable);
    
    DataColumn DC = new DataColumn();
    DC.ColumnName = "Test";
    DC.DataType = typeof(string);
    DC.Expression = string.Format("{0} + '-' + {1}", "title_id", "title");
    TitlesTable.Columns.Add(DC);
    
    comboBox1.DataSource = TitlesTable;
    comboBox1.DisplayMember = "Test";
    comboBox1.ValueMember = "title_id";
