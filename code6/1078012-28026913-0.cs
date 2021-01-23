            //put columns in order of display
            List<DataGridViewColumn> columnsInOrder = new List<DataGridViewColumn>();
            foreach(DataGridViewColumn c in this.dataGridView1.Columns)
            {
                columnsInOrder.Add(c);
            }
            columnsInOrder = columnsInOrder.OrderBy(c => c.DisplayIndex).ToList();
            //read rows into lines of strings that can be exported as a CSV file
            List<string> CSVExportLines = new List<string>();
            foreach(DataGridViewRow r in this.dataGridView1.Rows)
            {
                List<string> valuesInOrder = new List<string>();
                //go through columns by order of display index, pull values by the "real" index
                foreach(DataGridViewColumn c in columnsInOrder)
                {
                    valuesInOrder.Add(r.Cells[c.Index].ToString());
                }
                CSVExportLines.Add(string.Join(",", valuesInOrder.ToArray())); //add one CSV line (join all individual values into a string with commas in between)
            }
            File.WriteAllLines("C:\somepath\somefile.csv", CSVExportLines.ToArray());
