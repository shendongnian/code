    using NPOI.SS.UserModel;
    using NPOI.HSSF.UserModel;  
    using NPOI.HSSF.Util;
     public void DataTablesToXls(Dictionary<string,  DataTable> retailerTables, String filename, String allName)
        {
            var keys = new List<string>(retailerTables.Keys);
            HSSFWorkbook xlsWorkBook = new HSSFWorkbook();
            IFont hlink_font = xlsWorkBook.CreateFont();
            ICellStyle hlink_style = xlsWorkBook.CreateCellStyle();
            HSSFFont bestpriceFont = (HSSFFont)xlsWorkBook.CreateFont();
            HSSFCellStyle bestpriceStyle = (HSSFCellStyle)xlsWorkBook.CreateCellStyle();
            bestpriceFont.Color = HSSFColor.Blue.Index;
            bestpriceStyle.FillForegroundColor = HSSFColor.Blue.Index;
            bestpriceStyle.SetFont(bestpriceFont);
   
            HSSFFont priceFont = (HSSFFont)xlsWorkBook.CreateFont();
            HSSFCellStyle priceStyle = (HSSFCellStyle)xlsWorkBook.CreateCellStyle();
            priceFont.Color = HSSFColor.Red.Index;
            bestpriceStyle.FillForegroundColor = HSSFColor.Red.Index;
            priceStyle.SetFont(priceFont);
            HSSFFont matchFont = (HSSFFont)xlsWorkBook.CreateFont();
            HSSFCellStyle matchStyle = (HSSFCellStyle)xlsWorkBook.CreateCellStyle();
            matchFont.Color = HSSFColor.Green.Index;
            matchStyle.FillForegroundColor = HSSFColor.Green.Index;
            matchStyle.SetFont(matchFont);
            HSSFFont ordinaryFont = (HSSFFont)xlsWorkBook.CreateFont();
            HSSFCellStyle ordinaryStyle = (HSSFCellStyle)xlsWorkBook.CreateCellStyle();
            ordinaryFont.Color = HSSFColor.Black.Index;
            ordinaryStyle.FillForegroundColor = HSSFColor.Black.Index;
            ordinaryStyle.SetFont(ordinaryFont);
            Dictionary<string, HSSFCellStyle> fonts = new Dictionary<string,HSSFCellStyle>();
             fonts.Add("best", bestpriceStyle);
             fonts.Add("price", priceStyle);
             fonts.Add("match", matchStyle);
             fonts.Add("ordinary", ordinaryStyle);
                
            string keyFont = "ordinary";
            foreach (string key in keys)
            {
                if (!(@key.Equals(allName)))
                {
                    DataTable dt = retailerTables[key];
                    ISheet retailerWorkSheet = xlsWorkBook.CreateSheet(@key);
                  
                    IRow header = retailerWorkSheet.CreateRow(0);
                    int rcount = 0;
                    int colCount = 0;
                    colCount = 0;
                    IRow rheader = retailerWorkSheet.CreateRow(rcount);
                    foreach (DataColumn column in dt.Columns)
                    {
                        // Console.WriteLine(row[column]);
                        ICell c = rheader.CreateCell(colCount);
                        // c.SetCellValue(dt.Rows[0][column].ToString());
                        c.SetCellValue(@column.ToString());
                        colCount++;
                    }
                    Boolean matchRow = false;
                    rcount++;
                    foreach (DataRow row in dt.Rows)
                    {
                        colCount = 0;
                        IRow r = retailerWorkSheet.CreateRow(rcount);
                        Boolean bestpriceRow = false;
                        if (allName.Equals("all"))
                        {
                            if (row[dt.Columns[2]].Equals(@key))   // handling all data 
                            {
                                bestpriceRow = true;
                                keyFont = "best";
                            } else {
                                keyFont = "price";
                            }
                        }
                        
                        foreach (DataColumn column in dt.Columns)
                        {
                            // Console.WriteLine(row[column]);
                            HSSFCell c = (HSSFCell)r.CreateCell(colCount);
                           // retailerWorkSheet.AutoSizeColumn(column.Ordinal);
                       
                        
                            String rowVal = row[column].ToString();
                            if (allName.Equals("none")) {
                                if (row[dt.Columns[3]].Equals(rowVal))   // handling all data 
                                {
                                    bestpriceRow = false; // show in red
                                    matchRow = true;
                                    keyFont = "match";
                                }
                                else
                                {
                                    bestpriceRow = false;
                                    matchRow = false;
                                    keyFont="ordinary";
                                }
                            }
                            //        if (@key.Equals("all"))
                            //        {
                            //     hlink_font.Color = HSSFColor.Black.Index;
                            //     hlink_style.SetFont(hlink_font);
                            //       } else {
                       //     if (rowVal.Equals(@key))
                       //     {
                       //         bestpriceRow = true;
                      //      }
                            //       }
                            if (rowVal != null)
                            {
                                if (rowVal.IndexOf("=HYPERLINK") != -1)
                                {
                                    string[] celldata = new string[2];
                                    celldata = getCellData(rowVal);
                                   // rowVal.IndexOf("\""); 
                                    
                                  //  rowVal = rowVal.Replace("=HYPERLINK", "");
                                    //rowVal = rowVal.Replace("(", "");
                                   // rowVal = rowVal.Replace(")", "");
                                  //  rowVal = rowVal.Replace("\",\"", ";");
                                 //   string[] words = rowVal.Split(';');
                                    if (celldata!=null)
                                    {
                                   //     string cellValue = words[1];
                                        string cellLink = celldata[0];
                                   //     cellValue = cellValue.Replace("\"", "");
                                     //   cellLink = cellLink.Replace("\"", "");
                                        string cellValue = celldata[1];
                                        HSSFHyperlink link = new HSSFHyperlink(HyperlinkType.Url);
                                        link.Address = cellLink;
                                        c.SetCellValue(cellValue);
                                        c.Hyperlink = (link);
                                        c.CellStyle= fonts[@keyFont];
                                   /*     if (bestpriceRow)
                                        {
                                            
                                            c.CellStyle = bestpriceStyle;
                                        }
                                        else
                                        {
                                            if (matchRow)
                                            {
                                                c.CellStyle = matchStyle;
                                            }
                                            else
                                            {
                                                c.CellStyle = priceStyle;
                                            }
                                        } */
                                    }
                                }
                                else
                                {
                                    c.SetCellValue(row[column].ToString());
                                       c.CellStyle= fonts[@keyFont];
                                 /*   if (bestpriceRow)
                                    {
                                        c.CellStyle = bestpriceStyle;
                                    }
                                    else
                                    {
                                        if (matchRow)
                                        {
                                            c.CellStyle = matchStyle;
                                        }
                                        else
                                        {
                                            c.CellStyle = priceStyle;
                                        }
                                    } */
                                }
                            }
                            else
                            {
                                c.SetCellValue(row[column].ToString());
                                c.CellStyle= fonts[@keyFont];
                               /* if (bestpriceRow)
                                {
                                    c.CellStyle = bestpriceStyle;
                                }
                                else
                                {
                                    if (matchRow)
                                    {
                                        c.CellStyle = matchStyle;
                                    }
                                    else
                                    {
                                        c.CellStyle = priceStyle;
                                    }
                                } */
                            }
                            colCount++;
                        }
                        rcount++;
                    }
                }
                
              //  retailerTables[key] 
            }
            string folderPath = Server.MapPath("~/Content/data");
            string datafile = Path.Combine(folderPath, filename);
            FileStream file = new FileStream(datafile, FileMode.CreateNew);
            xlsWorkBook.Write(file);
            file.Close();
        }
