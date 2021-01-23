    arrData = clsData.GetReport(strStartDate, strEndDate);
                dataCount = arrData.Count;
                string col = "B";
                foreach (string item in arrData)
                {
                    string[] stuff = item.Split('\t');
                    if (stuff[0].Equals("Machine1"))
                    {
                         if (stuff[5].Equals("M")) 
                         {
                            row = 5;
                            ws.Cells[row, col] = stuff[1];                   // Morning Shift Total 
                            col = IncCol(col);
                         }
                         else 
                         {
                             if (stuff[5].Equals("N")) 
                             {
                                row = 6;
                                ws.Cells[row, col] = stuff[1];                   //Night Shift Total 
                                col = IncCol(col);
                             }
                         }
                    }                  
                    else 
                    {
                        if (stuff[0].Equals("Machine2"))
                        {
                            if (stuff[5].Equals("M"))
                            {
                                row = 10;
                                ws.Cells[row, col] = stuff[1];                   //Morning Shift Total 
                                col = IncCol(col);
                            }
                            else
                            {
                                if (stuff[5].Equals("N"))
                                {
                                    row = 11;
                                    ws.Cells[row, col] = stuff[1];                   //Night Shift Total 
                                    col = IncCol(col);
                                }
                            }
                        }
                    }
                   
