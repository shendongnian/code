    var v = "ID=1;Name='XYZ';ID=2;Name='PQR';";
            string newRow = "ID";
            var values = v.Replace(";", ",");
            values = values.Remove(values.Length - 1, 1);
            var cols = values.Split(',');
            string pattern = Regex.Escape(cols[0].Split('=')[0]);
            var matches = Regex.Matches(v, "\\b" + pattern + "\\b", RegexOptions.IgnoreCase);
            int count = matches.Count;
            DataTable dt = new DataTable();
            for (int i = 0; i < cols.Length; i++)
            {
                var p = cols[i].Split('=');
                if (!dt.Columns.Contains(p[0].ToString()))
                    dt.Columns.Add(p[0].ToString());
            }
            DataRow dr = null;
            for (int k = 0; k < count; k++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    var value = cols[j].Split('=');
                    if (value[0] == newRow)
                    {
                        dr = dt.NewRow();
                        dr[j] = value[1];
                    }
                    else
                    {
                        dr[j] = value[1];
                    }
                }
                dt.Rows.Add(dr);
            }
        }
