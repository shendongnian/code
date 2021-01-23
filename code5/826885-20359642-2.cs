     DataGridViewComboBoxColumn colFilterType = new DataGridViewComboBoxColumn();
     colFilterType.HeaderText = "Name you want";
     colFilterType.DataSource = Enum.GetValues(typeof(FilterType));
     colFilterType.ValueType = typeof(FilterType);
     dataGridView1.Columns.Add(colFilterType);
