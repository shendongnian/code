        int iRow = 0;
        foreach (DataRow r in dt.Rows)
        {
            iRow++;
            //add each row's cell data...
            iCol = 0;
            foreach (DataColumn c in dt.Columns)
            {
                iCol++;
                try
                {
                    DateTime date = Convert.ToDateTime(r[c.ColumnName]);
                    excel.Cells[iRow + 1, iCol] = String.Format("{0:MM/dd/yyyy", date);
                }
                catch(Exception e)
                {
                    excel.Cells[iRow + 1, iCol] = r[c.ColumnName];
                }
                
            }
        }
