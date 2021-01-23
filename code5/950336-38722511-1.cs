         DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
         nameColumn.HeaderText = "Cat name";
         nameColumn.DataPropertyName = "Name"; 
         nameColumn.ReadOnly = true;
         DataGridViewComboBoxColumn genderColumn = new DataGridViewComboBoxColumn ();
         List<string> genderList = new List<string>() { "male", "female", "unknown" };
         genderColumn.DataSource = genderList;
         genderColumn.HeaderText = "Gender";
         genderColumn.DataPropertyName = "Gender";
         genderColumn.ValueType = typeof(string);
         
         myDataGridView.DataSource = myData;
         myDataGridView.Columns.AddRange(nameColumn, genderColumn);
