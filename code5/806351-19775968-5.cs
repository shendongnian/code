            DataTable table = new DataTable();
            table.Columns.Add("Topic");
            table.Columns.Add("County");
            table.Columns.Add("Allocated");
            table.Columns.Add("Not Allocated");
            table.Columns.Add("Total");
            foreach(Datum entry in MyData.Values)
            {
                DataRow NewDataRow = table.NewRow();
                NewDataRow.ItemArray = new string[5]
                {
                    entry.Topic,
                    entry.County,
                    entry.Allocated.ToString(),
                    entry.NotAllocated.ToString(),
                    entry.Total().ToString()
                };
                table.Rows.Add(NewDataRow);
            }
