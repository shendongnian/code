    string cusip = Convert.ToString((range.Cells[rCnt, 3] as Excel.Range).Value2);
    
    if (!string.IsNullOrEmpty(cusip))
    {
        if (cusip.Length > 8)
        {
            cusip = cusip.Substring(0,8);
        }
    }
    else
    {
        cusip = "000000cm";
    }
    
    cusipList.Add(cusip);
