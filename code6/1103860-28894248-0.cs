      private void ReadCsv()
        {
            string filePath = @"C:\..\20130102.csv";
            FileStream fileStream = null;
            try
            {
                fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            }
            catch (Exception ex)
            { 
                return;
            }
            DataTable table = new DataTable();
            bool isColumnCreated = false;
            using (StringReader reader = new StringReader(new StreamReader(fileStream, Encoding.Default).ReadToEnd()))
            {
                while (reader.Peek() != -1)
                {
                    string line = reader.ReadLine();
                    if (line == null || line.Length == 0)
                        continue; 
                    string[] values = line.Split(',');
                    if(!isColumnCreated)
                    {
                        for(int i=0; i < values.Count(); i++)
                        {
                            table.Columns.Add("Column" + i);
                        }
                        isColumnCreated = true;
                    }
                    DataRow row = table.NewRow();
                    for(int i=0; i < values.Count(); i++)
                    {
                        row[i] = values[i];
                    }
                    table.Rows.Add(row);
                }
            }
            dataGridView1.DataSource = table;
        }
