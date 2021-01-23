    string cusip; 
    cusip = Convert.ToString((range.Cells[rCnt, 3] as Excel.Range).Value2);
    
    if (!string.IsNullOrEmpty(cusip))
    {
        cusip = (cusip.Length > 7) ? cusip.Substring(0,8) : cusip;
    } else {
        cusip = "000000cm";
    }
    
    cusipList.Add(cusip);
