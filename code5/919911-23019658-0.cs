    public bool noFormulas(Excel.Worksheet dataSheet)
    {
       Excel.Range beginRange = dataSheet.Cells[3, beginColumn];
       Excel.Range endRange = dataSheet.Cells[lastRow, endColumn];
       Excel.Range fullRange = dataSheet.Range[beginRange, endRange];
       foreach (Excel.Range c in fullRange) 
       {
          if (c.HasFormula)
          {
             return false;
          }
       }
       return true;
    }
