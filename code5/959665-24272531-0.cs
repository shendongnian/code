     private void button1_Click(object sender, EventArgs e)
        {
            //Create a Datatable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Col1");
            dataTable.Columns.Add("Col2");
            //For each key pair
            foreach (KeyValuePair<string, List<string>> keyValuePair in dict)
            {
                List<string> list = keyValuePair.Value;
                //Add a row for the each item in list
                foreach (var item in list)
                {
                    DataRow row = dataTable.NewRow();
                    row["Col1"] = keyValuePair.Key;
                    row["Col2"] = item;
                    dataTable.Rows.Add(row);    
                }
            }
            this.dataGridView1.DataSource = dataTable;
        }
