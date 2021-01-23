    private void FitToContent()
        {
            int numCols ;
            int i ;
            numCols = dg.Columns.Count() ;
            i = 0 ;
            // where dg is your data grid's name...
            foreach (DataGridColumn column in dg.Columns)
            {
                if(i < numCols)
                { 
                    //if you want to size ur column as per the cell content
                    column.Width = new DataGridLength(1.0, DataGridLengthUnitType.SizeToCells);
                    //if you want to size ur column as per the column header
                    column.Width = new DataGridLength(1.0, DataGridLengthUnitType.SizeToHeader);
                    //if you want to size ur column as per both header and cell content
                    column.Width = new DataGridLength(1.0, DataGridLengthUnitType.Auto);
                }
                else
                {
                    column.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
                }
                i++ ;
            }
        }
