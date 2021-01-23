     string GetJson(DataTable table)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dataRow in table.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn column in table.Columns)
                {
                    row.Add(column.ColumnName.Trim(), dataRow[column]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }
