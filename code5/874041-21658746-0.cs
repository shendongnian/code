            foreach (DataRow row in dt.Rows)
            {
                var sb = new StringBuilder();
                foreach (DataColumn col in dt.Columns)
                {
                    sb.Append(row[col] + "\t");
                }
                ListBox1.Items.Add(sb.ToString());
            }
