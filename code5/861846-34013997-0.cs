                    dataView.Columns["yourColoumn"].Visible = false;
                    DataGridViewComboBoxColumn cmbCol = new DataGridViewComboBoxColumn();
                    cmbCol.HeaderText = "yourColumn";
                    cmbCol.Name = "myComboColumn";
                    cmbCol.Items.Add("True");
                    cmbCol.DataSource = myList();
                    dataView.Columns.Add(cmbCol);
                    dataView.Columns["myComboColumn"].DisplayIndex = "at any index that you want";
    
                    foreach (DataGridViewRow row in dataView.Rows)
                    {
                        row.Cells["myComboColumn"].Value = row.Cells["yourColumn"].Value;
                    } 
