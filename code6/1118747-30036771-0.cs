    private void AddToList(DataTable dt)
        {
            possibleWords = 0;
            // Cleans the data grid view
            WordList.DataSource = null;
            WordList.Refresh();
            // Let's transform the original data table onto another, changing rows by columns
            DataTable table = new DataTable();
            for (int i = 0; i < 10; i++)
            {
                table.Columns.Add(Convert.ToString(i));
            }
            DataRow r;
            int col = 0;
            //for (int k = 0; k < dt.Columns.Count; k++)
            {
                r = table.NewRow();
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (col >= 10)
                    {
                        table.Rows.Add(r);
                        col = 0;
                        r = table.NewRow();
                    }
                    r[col++] = (dt.Rows[j][0]).ToString().ToUpper();
                    possibleWords++;
                }
                table.Rows.Add(r);
            }
            // Puts the new data table as datasource of the word list
            DataView dv = table.DefaultView;
            WordList.DataSource = dv;
            if (possibleWords == 0)
                return;
            WordList.Columns[0].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            WordList.ColumnHeadersVisible = false;
            WordList.RowHeadersVisible = false;
        }
