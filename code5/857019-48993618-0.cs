                    gvEmployees.AutoGenerateColumns = false;
                    gvEmployees.ColumnCount = 4;
                    DataGridViewButtonColumn SelectButton = new DataGridViewButtonColumn();
                    SelectButton.Name = "Select";
                    SelectButton.Text = "Select";
                    SelectButton.UseColumnTextForButtonValue = true;
                    if (gvEmployees.Columns["Select"] == null)
                    {
                        gvEmployees.Columns.Insert(0, SelectButton);
                    }
                    DataGridViewButtonColumn DeleteButton = new DataGridViewButtonColumn();
                    DeleteButton.Name = "Delete";
                    DeleteButton.Text = "Delete";
                    DeleteButton.UseColumnTextForButtonValue = true;
                    if (gvEmployees.Columns["Delete"] == null)
                    {
                        gvEmployees.Columns.Insert(1, DeleteButton);
                    }
                    gvEmployees.Columns[2].Name = "EmployeeID";
                    gvEmployees.Columns[2].HeaderText = "EmployeeID";
                    gvEmployees.Columns[2].DataPropertyName = "EmployeeID";
