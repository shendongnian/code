    public static List<T> MapTableToList<T>(this DataTable table) where T : new()
    {
            List<T> result = new List<T>();
            var Type = typeof(T);
            foreach (DataRow row in table.Rows)
            {
                T item = new T();
                foreach (var property in Type.GetProperties())
                {
                    if(table.Columns.IndexOf(property.Name) > -1)
                    {
                        if (row[table.Columns[property.Name]] == System.DBNull.Value && property.GetMethod.ReturnType.Name.IndexOf("Nullable") > -1)
                        {
                            property.SetMethod.Invoke(item, new object[] { null });
                        }
                        else
                        {
                            property.SetMethod.Invoke(item, new object[] { row[table.Columns[property.Name]] });
                        }
                    }
                }
                result.Add(item);
            }
            return result;
    }
