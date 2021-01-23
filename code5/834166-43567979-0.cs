    public static class Extension
    {
        public static IList<T> ToList<T>(this DataTable dt, bool isFirstRowColumnsHeader = false) where T : new()
        {
            var results = new List<T>();
            if (dt != null && dt.Rows.Count > 0)
            {
                var columns = dt.Columns.Cast<DataColumn>().ToList();
                var rows = dt.Rows.Cast<DataRow>().ToList();
                var headerNames = columns.Select(col => col.ColumnName).ToList();
                //
                // Find properties name or columns name
                if (isFirstRowColumnsHeader)
                {
                    for (var i = 0; i < headerNames.Count; i++)
                    {
                        if (rows[0][i] != DBNull.Value && !string.IsNullOrEmpty(rows[0][i].ToString()))
                            headerNames[i] = rows[0][i].ToString();
                    }
                    //
                    // remove first row because that is header
                    rows.RemoveAt(0);
                }
                // Create dynamic or anonymous object for `T type
                if (typeof(T) == typeof(System.Dynamic.ExpandoObject) ||
                    typeof(T) == typeof(System.Dynamic.DynamicObject) ||
                    typeof(T) == typeof(System.Object))
                {
                    var dynamicDt = new List<dynamic>();
                    foreach (var row in rows)
                    {
                        dynamic dyn = new ExpandoObject();
                        dynamicDt.Add(dyn);
                        for (var i = 0; i < columns.Count; i++)
                        {
                            var dic = (IDictionary<string, object>)dyn;
                            dic[headerNames[i]] = row[columns[i]];
                        }
                    }
                    return (dynamic)dynamicDt;
                }
                else // other types of `T
                {
                    var properties = typeof(T).GetProperties();
                    if (columns.Any() && properties.Any())
                    {
                        foreach (var row in rows)
                        {
                            var entity = new T();
                            for (var i = 0; i < columns.Count; i++)
                            {
                                if (!row.IsNull(columns[i]))
                                {
                                    typeof(T).GetProperty(headerNames[i])? // ? -> maybe the property by name `headerNames[i]` is not exist in entity then get null!
                                        .SetValue(entity, row[columns[i]] == DBNull.Value ? null : row[columns[i]]);
                                }
                            }
                            results.Add(entity);
                        }
                    }
                }
            }
            return results;
        }
    }
