     var dataTable = new DataTable();
     dataTable.Columns.Add("Message", typeof(string));
     dataTable.Rows.Add("No items found");
                    
     myDataGridView.DataSource = new BindingSource { DataSource = dataTable };
     myDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
