    Excel.Worksheet dummy = finalized.Worksheets[1];
    
    for (int i = 2; i <= excel.Workbooks.Count; i++)
    {
        int count = excel.Workbooks[i].Worksheets.Count;
    
        for (int j = 1; j <= count; j++)
        {
            Excel._Worksheet pastee = (Excel._Worksheet)excel.Workbooks[i].Worksheets[j];
            pastee.Copy(dummy);
        }
    }
    
    dummy.Delete();
