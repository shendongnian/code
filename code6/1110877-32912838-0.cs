                            //This method is very slow.
                            // Storing Each row and column value to excel sheet
                            //for (int k = 0, k2 = 2; k < table.Rows.Count; k++, k2++)
                            //{
                            //    for (int l = 0, l1 = 1; l < table.Columns.Count; l++, l1++)
                            //    {
                            //        //ExcelApp.Cells[k2, l1] =
                            //        //    table.Rows[k].ItemArray[l].ToString();
                            //        ExcelApp.Cells[k2, l1] =
                            //            table.Rows[k][l].ToString();
                            //    }
                            //}
    
                            ////////////////
    
                            //See if this method is faster
                            // transform formated data into string[,]
    //                        var excelData = new string[table.Rows.Count, table.Columns.Count];
                            var excelData = new object[table.Rows.Count, table.Columns.Count];
                            for (int rowJ = 0; rowJ < table.Rows.Count; rowJ++)
                            {
                                for (int colI = 0; colI < table.Columns.Count; colI++)
                                {
    //                                excelData[rowJ, colI] = table.Rows[rowJ][colI].ToString();
                                    excelData[rowJ, colI] = table.Rows[rowJ][colI];
                                    //excelData[colI, rowJ] = "test";
                                }
                            }
                            //<Code to set startLoc and endLoc removed>
    
                            Range valRange = ExcelApp.get_Range(startLoc, endLoc);
                            valRange.Value2 = excelData;
