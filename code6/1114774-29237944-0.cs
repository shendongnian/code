     SqlBulkCopy cm = new SqlBulkCopy(con);
                cm.DestinationTableName = "test2";
                cm.ColumnMappings.Add("C1", "C1");
                cm.ColumnMappings.Add("C2", "C2");
                cm.ColumnMappings.Add("C3", "C3");
                cm.ColumnMappings.Add("C4", "C4");
                cm.ColumnMappings.Add("C5", "C5");
                try
                {
                    cm.WriteToServer(dataGridView1.DataSource);
                    MessageBox.Show("Total Record Inserted");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
