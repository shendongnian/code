            Dictionary<string, Dictionary<string, object>> rows = new Dictionary<string, Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dts.Rows)
            {
                row = new Dictionary<string, object>();
                var columns = dts.Columns;
                
                for (int i = 1; i < columns.Count; i++)
                {
                    row.Add(columns[i].ColumnName, dr[columns[i]]);
                }
                if (rows.ContainsKey(columns[0].ColumnName))
                    rows[columns[0].ColumnName] = rows[columns[0].ColumnName].Concat(row).ToDictionary(p=>p.Key,v=>v.Value);
                else
                    rows[columns[0].ColumnName] = row;
            }
