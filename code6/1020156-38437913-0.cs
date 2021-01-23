    for (int row = 1; row <= lastRow; row++)
        {
        DateTime dt;
        if (DateTime.TryParse(worksheet.Cells[row, colWithDates]?.Value.ToString() ?? string.Empty, out dt))
        {
            worksheet.Cells[row, 1].Value = dt;
            worksheet.Cells[row, 1].Style.Numberformat.Format = "yyyy-mm-dd";
        }
                    
        TimeSpan ts;
        if (TimeSpan.TryParse(worksheet.Cells[row, columnWithTimes]?.Value.ToString() ?? string.Empty, out ts))
        {
            worksheet.Cells[row, 5].Value = ts;
            worksheet.Cells[row, 5].Style.Numberformat.Format = "hh:mm";
        }
    }
   
