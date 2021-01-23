    public static DataTable readCSV()
        {
            //create a data table and add the column's
            DataTable table = new DataTable("table_name");
            int i = 0;
            table.Columns.Add("city", typeof(String));
            table.Columns.Add("owner", typeof(String));
            table.Columns.Add("unit_number", typeof(String));
            table.Columns.Add("equipment_desc", typeof(String));
            table.Columns.Add("wo_type", typeof(String));
            table.Columns.Add("wo_number", typeof(String));
            table.Columns.Add("wo_desc", typeof(String));
            table.Columns.Add("wo_status", typeof(String));
            table.Columns.Add("days_oos", typeof(String));
            //start reading the textfile
            StreamReader reader = new StreamReader(@"c:\...\...csv");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (i == 0)
                {
                    //skip headings
                }
                else
                {
                    string[] items = line.Split('\t');
                    //make sure it has 3 items
                    if (items.Length == 9)
                    {
                        DataRow row = table.NewRow();
                        row["city"] = items[0];
                        row["owner"] = items[1];
                        row["unit_number"] = items[2];
                        row["equipment_desc"] = items[3];
                        row["wo_type"] = items[4];
                        row["wo_number"] = items[5];
                        row["wo_desc"] = items[6];
                        row["wo_status"] = items[7];
                        row["days_oos"] = items[8];
                        table.Rows.Add(row);
                    }
                }
                i++;
            }
            reader.Close();
            reader.Dispose();
            // make use of the table
            return table;
        }
