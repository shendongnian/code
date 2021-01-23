         for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
              {
                 for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                     {
                        if (range.Cells[rCnt, cCnt].Value2 is string)
                           {
                              str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                              if (str == null)
                              {
                                Console.WriteLine("null");
                              }
                              else
                              {
                                // str.Replace("\\", "");
                                //  string[] words = str.Split(' ');
                                foreach (string arrs in arr)
                                {
                                   if (str.Contains(arrs))
                                   {
                                     //foreach (string word in words)
                                     //{
                                     //    if (word == arrs)
                                     //    {
                                     var cell = (range.Cells[rCnt, cCnt] as Excel.Range);
                                     cell.Font.Bold = 1;
                                     cell.Font.Color= System.Drawing.ColorTranslator
                                                      .ToOle(System.Drawing.Color.Red);
                                                                        
                                           }
    
                                   }
                               //  }
                                 //}
                         }
     }
