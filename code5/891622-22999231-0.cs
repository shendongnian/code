     if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            int CoachingIndex = GetColumnIndexByName(e.Row, "Coaching");   
            TimeSpan timeStamp;
            string timeStampString = e.Row.Cells[CoachingIndex].Text; // just change the index of cells to get the correct timestamp field
            if (TimeSpan.TryParse(timeStampString, out timeStamp))
            {
                TimeSpan TS = timeStamp;
                int mins = TS.Minutes;
                int hours = TS.Hours;
                int days = TS.Days;
                if (mins > 40 || hours >= 1 || days >= 1)
                {
                    e.Row.Cells[CoachingIndex].BackColor = System.Drawing.Color.Red;                    
                }
            }            
        }
    }
    int GetColumnIndexByName(GridViewRow row, string columnName)
    {
        int columnIndex = 0;
        foreach (DataControlFieldCell cell in row.Cells)
        {
            if (cell.ContainingField is BoundField)
                if (((BoundField)cell.ContainingField).DataField.Equals(columnName))
                    break;
            columnIndex++; // keep adding 1 while we don't have the correct name
        }
        return columnIndex;
    }  
