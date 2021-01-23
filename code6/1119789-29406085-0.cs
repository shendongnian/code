            DataGridViewComboBoxColumn comboboxColumn;
            comboboxColumn = CreateComboBoxColumn();
            SetAlternateChoicesUsingDataSource(comboboxColumn);
            comboboxColumn.HeaderText = "TitleOfCourtesy (via DataSource property)";
            DataGridView1.Columns.Insert(0, comboboxColumn);
    
            comboboxColumn = CreateComboBoxColumn();
            SetAlternateChoicesUsingItems(comboboxColumn);
            comboboxColumn.HeaderText = "TitleOfCourtesy (via Items property)";
            // Tack this example column onto the end.
            DataGridView1.Columns.Add(comboboxColumn);
        private DataGridViewComboBoxColumn CreateComboBoxColumn()
        {
            DataGridViewComboBoxColumn column =
                new DataGridViewComboBoxColumn();
            {
                column.DataPropertyName = ColumnName.TitleOfCourtesy.ToString();
                column.HeaderText = ColumnName.TitleOfCourtesy.ToString();
                column.DropDownWidth = 160;
                column.Width = 90;
                column.MaxDropDownItems = 3;
                column.FlatStyle = FlatStyle.Flat;
            }
            return column;
        }
    private void SetAlternateChoicesUsingDataSource(DataGridViewComboBoxColumn comboboxColumn)
        {
            {
                comboboxColumn.DataSource = RetrieveAlternativeTitles();
                comboboxColumn.ValueMember = ColumnName.TitleOfCourtesy.ToString();
                comboboxColumn.DisplayMember = comboboxColumn.ValueMember;
            }
        }
    
        private DataTable RetrieveAlternativeTitles()
        {
            return Populate("SELECT distinct TitleOfCourtesy FROM Employees");
        }
