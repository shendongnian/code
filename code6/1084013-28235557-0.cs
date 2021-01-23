        //Iterate the rows in the used range
        foreach (Excel.Range row in usedRange.Rows)
        {
            for (int i = 0; i < row.Columns.Count; i++)
            {
                spreadsheetrows.Add(new SPREADSHEETModel.spreadsheetRow()
                {
			if (row.Cells[i + 1, 1].Value2 != null)
			{	                    
				col1 = row.Cells[i + 1, 1].Value2.ToString();
			}
			if (row.Cells[i + 1, 2].Value2 != null)
			{
                    		col2 = row.Cells[i + 1, 2].Value2.ToString();
			}
			if (row.Cells[i + 1, 3].Value2 != null)
			{
                    		col3 = row.Cells[i + 1, 3].Value2.ToString();
			}
                });
            }
        }
