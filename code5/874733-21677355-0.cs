    for (int row = startRowParcel + 1; row <= endRowParcel; row++) {
        List<string> rateRow = new List<string>();
    
        for (int col = startColumnNsa; col <= endColumnNsa; col++) {
            if (Convert.ToString(ws.Cells[row, col].Value) == null)
                rateRow.Add("0");
            else if (Convert.ToString(ws.Cells[row, col].Value) == "1/2")
                rateRow.Add("0.5");
            else
                rateRow.Add(Convert.ToString(ws.Cells[row, col].Value));
        }
        
        if (rateRow.Any(x=> x != "0"))
        tbPriority.Rows.Add(rateRow.ToArray());
    } 
