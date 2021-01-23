        public string DataRowToJSON(System.Data.DataRow row)
        {
            System.Collections.Generic.List<string> Fields = new System.Collections.Generic.List<string>();
            foreach (System.Data.DataColumn item in row.Table.Columns) Fields.Add(string.Format("\"{0}\":\"{1}\"", item.ColumnName, row[item].ToString()));
            return string.Format("{{{0}}}", string.Join(",", Fields));
        }
