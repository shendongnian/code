        private void Vaidate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ENTRY/CMD #", typeof(int));
            dt.Columns.Add("REFERENCE 1", typeof(string));
            dt.Columns.Add("REFERENCE 3", typeof(string));
            DataRow dr;
            for (int i = 0; i < 20; i++)
            {
                dr = dt.NewRow();
                dr[0] = i;
                dr[1] = "This" + i.ToString();
                dr[2] = "This" + i.ToString();
                dt.Rows.Add(dr);
            }
            dt.Rows[5][2] = "";
            dt.Rows[8][1] = "";
            //int itemFind = 157;
            //int rowindex = dt.Rows.IndexOf(dt.Select("Id=" + itemFind).FirstOrDefault());
            //List<string> strImportRequiredFields = new List<string> { "ENTRY/CMD #", "PART #", "REFERENCE 1", "REFERENCE 2", "REFERENCE 3", "DUTY PER" };
            List<string> strImportRequiredFields = new List<string> { "ENTRY/CMD #", "REFERENCE 1", "REFERENCE 3", };
            List<string> columnsPresent = dt.Columns.Cast<DataColumn>().Select(a => a.ColumnName).ToList();
            List<string> columnsNotPresent = strImportRequiredFields.Except(columnsPresent).ToList();
            if (columnsNotPresent != null && columnsNotPresent.Count > 0)
            {
                MessageBox.Show("Columns must present" + Environment.NewLine + columnsNotPresent.Aggregate((a, b) => a + "," + b));
                return;
            }
            string s = strImportRequiredFields.Aggregate((acc, next) => acc + next + " is Null or");
            var result = dt.AsEnumerable().Where(p => strImportRequiredFields.Any(t => string.IsNullOrEmpty(p[t].ToString())));
            List<int> Invalidrows = new List<int>();
            foreach (DataRow item in result)
            {
                Invalidrows.Add(dt.Rows.IndexOf(item));
            }
            if (Invalidrows != null && Invalidrows.Count > 0)
            {
                MessageBox.Show("some of field data missing in below rows" + Environment.NewLine + Invalidrows.Aggregate(
                            new StringBuilder(),
                            (sb, x) => sb.AppendLine(x.ToString())
                        ));
               
                return;
            }
        }
