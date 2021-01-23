    for (rCnt = 1; rCnt <= xlRange.Rows.Count; rCnt++)
                {
                    for (cCnt = 1; cCnt <= xlRange.Columns.Count; cCnt++)
                    {
                        string temp = (string)(xlRange.Cells[rCnt,Ccnt] as Excel.Range).Value2;
                        Console.WriteLine(temp);
                    }
                }
