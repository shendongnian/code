    if (str == text.ToString())
    {
      var cell = (range.Cells[rCnt, cCnt] as Excel.Range);
      cell.Font.Bold = 1;
      cell.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red); 
    }
