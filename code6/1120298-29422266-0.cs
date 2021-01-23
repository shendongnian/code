            DataTable result = new DataTable();
            result.Columns.Add("col1", typeof(object));
            result.Columns.Add("col2", typeof(object));
            // assuming both data tables have the same length
            for (int row = 0; row < dtTab1.Rows.Count; row++)
            {
                DataRow dr;
                dr = result.NewRow();
                dr[0] = dtTab1.Rows[row][0];
                dr[1] = dtTab2.Rows[row][0];
                result.Rows.Add(dr);
            }
