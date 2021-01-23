    int rowCount = range.Rows.Count;
    int colCount = range.Columns.Count;
    string[] headers = new string[colCount+1];
    for (cCnt = 1; cCnt <= colCount; cCnt++)
        {
            headers[cCnt]  = (Convert.ToString((range.Cells[rCnt, cCnt] as Excel.Range).Value2));
        }
    for (rCnt = 2; rCnt <= rowCount; rCnt++)
    {
        for (cCnt = 1; cCnt <= colCount; cCnt++)
        {                
            str = (Convert.ToString((range.Cells[rCnt, cCnt] as Excel.Range).Value2));
            Console.Write(heasders[cCnt]);
            Console.Write(" ");
            Console.WriteLine(str);
        }
        Console.WriteLine("----------------");
    }
    Console.ReadLine();
