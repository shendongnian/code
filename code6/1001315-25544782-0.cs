    public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            DataTable dt = new DataTable();
            foreach (var prop in data.First().GetType().GetProperties())
            {
                dt.Columns.Add(prop.Name);
            }
            foreach (T entry in data)
            {
                List<object> newRow = new List<object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    var val = entry.GetType().GetProperty(dc.ColumnName).GetValue(entry, null);
                    newRow.Add(val);
                }
                dt.Rows.Add(newRow.ToArray());
            }
            return dt;
        }
