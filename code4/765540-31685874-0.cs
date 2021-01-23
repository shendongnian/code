    _dataGrid.DataBindingComplete += (o, _) =>
        {
            var dataGridView = o as DataGridView;
            if (dataGridView != null)
            {
               dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
               dataGridView.Columns[dataGridView.ColumnCount-1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        };
