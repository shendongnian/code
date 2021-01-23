            for (int i = 0; i < SomeDetails.Rows.Count; i++)
            {
                string row = "";
                for (int j = 0; j < SomeDetails.Columns.Count; j++)
                {
                    row += SomeDetails.Rows[i][SomeDetails.Columns[j].ColumnName].ToString() + " - ";
                }
                System.Diagnostics.Debug.WriteLine(row);
            }
