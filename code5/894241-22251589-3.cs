        // Datetime column content transformed in a formatted string....
        if(i == 1)
        {
           object cellValue = dr.Cells[i].Value;
           value = (cellValue == DBNull.Value ? 
                 string.Empty : Convert.ToDateTime(cellValue).ToString("yyyy/MM/dd hh:mm:ss");
        }
