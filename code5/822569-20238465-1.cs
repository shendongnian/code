                var obj = sender as ComboBox;
                string s = obj.SelectedItem.ToString();
                var y= (from x in ds.Tables.OfType<DataTable>() where x.TableName == s select x).ToList();
                if (ds.Tables.Count > 0)
                {
                    IList<string> lstCol = new List<string>();
                    for (int i = 0; i < y[0].Columns.Count; i++)
                    {
                          // Filling the list of columns according to the selected table
                        lstCol.Add(y[0].Columns[i].ToString());
                    }
                    // Setting dataSource for the column ComboBox
                    comboBox2.DataSource = lstCol;
                    //comboBox2.ValueType = typeof(string);
                }
                else
                {
                    comboBox2.DataSource = null;
                }
            }
            
