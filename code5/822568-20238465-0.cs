    private void Form1_Load_1(object sender, EventArgs e)
            {
                ds.Tables.Add(GetTable1());
                ds.Tables.Add(GetTable2());
    
                IList<string> lstTables = ds.Tables.OfType<DataTable>().Select(dt => dt.TableName).ToList();
                dataGridView1.DataSource = lstTables;
                comboBox1.DataSource = lstTables; //Setting the tables datasource for the comboBox.
            }
