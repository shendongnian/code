        public static DataTable ConvertToDataTable<T>(IEnumerable<T> data)
        {
            DataTable table = new DataTable();
            foreach (T item in data)
            {
                if (item is IDictionary<string, object> dict)
                {
                    foreach (var key in dict)
                    {
                        table.Columns.Add(key.Key, key.Value?.GetType() ?? typeof(object));
                    }
                    break;
                }
                foreach (var prop in typeof(T).GetProperties())
                {
                    table.Columns.Add(prop.Name, prop.PropertyType);
                }
                break;
            }
            DataRow row = null;
            foreach (T item in data)
            {
                if (item is IDictionary<string, object> dict)
                {
                    row = table.NewRow();
                    foreach (var key in dict)
                    {
                        row[key.Key] = key.Value;
                    }
                    table.Rows.Add(row);
                    continue;
                }
                row = table.NewRow();
                foreach (var prop in typeof(T).GetProperties())
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                table.Rows.Add(row);
            }
            return table;
        }
