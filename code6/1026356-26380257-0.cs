     DataGridView grid = new DataGridView();
                var nameColumn = new DataGridViewTextBoxColumn();
                nameColumn.Name = "Device Name";
                nameColumn.HeaderText = "Device Name";
                dgv.Columns.Add(nameColumn);
                
    
                var checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "Select";
                checkColumn.HeaderText = "Select";
                dgv.Columns.Add(checkColumn);
    
                string IN = "IN";
                string OUT = "OUT";
                var select = new DataGridViewComboBoxColumn();
                select.HeaderText = "Direction";
                select.Name = "Direction";
                select.Items.Add(IN);
                select.Items.Add(OUT);
                dgv.Columns.Add(select);
    
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    string DeviceName = row[0].ToString();
    
                     bool Enabled = false;
                    if (row[1].ToString() != "")
                        Enabled = Convert.ToBoolean( row[1].ToString());
    
                    string Direction = row[2].ToString();
    
                    DataGridViewRow dgRow = new DataGridViewRow();
                    dgv.Rows.Add(new object[] {DeviceName, Enabled, Direction});
                }
              
