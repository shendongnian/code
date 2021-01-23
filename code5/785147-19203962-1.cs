            // read each row from the start of the data (start row + 1 header row) to the end of the spreadsheet.
            for (int rowNumber = startRow + 1; rowNumber <= currentWorkSheet.Dimension.End.Row; rowNumber++)
            {
                List<object> columns = List<object>();
                columns.Add(currentWorkSheet.Cells[rowNumber, 1].Value);
                columns.Add(currentWorkSheet.Cells[rowNumber, 2].Value);
                columns.Add(currentWorkSheet.Cells[rowNumber, 3].Value);
                columns.Add(currentWorkSheet.Cells[rowNumber, 4].Value);
                columns.Add(currentWorkSheet.Cells[rowNumber, 5].Value);
                columns.Add(currentWorkSheet.Cells[rowNumber, 6].Value);
                columns.Add(currentWorkSheet.Cells[rowNumber, 7].Value);
                columns.Add(currentWorkSheet.Cells[rowNumber, 8].Value);
                columns.Add(currentWorkSheet.Cells[rowNumber, 9].Value);
                columns.Add(currentWorkSheet.Cells[rowNumber, 10].Value);
                columns.Add(currentWorkSheet.Cells[rowNumber, 11].Value);
                columns.Add(currentWorkSheet.Cells[rowNumber, 12].Value);
                columns.Add(currentWorkSheet.Cells[rowNumber, 13].Value);
                columns.Add(currentWorkSheet.Cells[rowNumber, 14].Value);
                columns.Add(currentWorkSheet.Cells[rowNumber, 15].Value);
                if (!columns.Contains(null))
                {
                    excelFileDataList.Add(new priceAddDelete
                    {
                        businessunitcode = columns[0].ToString(),
                        customerNumber = Convert.ToInt32(columns[1]),
                        productcode = columns[2].ToString(),
                        sizecode = columns[3].ToString(),
                        finishingmethodcode = columns[4].ToString(),
                        startdate = Convert.ToDateTime(columns[5]),
                        typeofprice = columns[6].ToString(),
                        pricetype = Convert.ToInt32(columns[7]),
                        typeofrent = Convert.ToInt32(columns[8]),
                        changesperweek = Convert.ToInt32(columns[9]),
                        adddelete = columns[10].ToString(),
                        price = Convert.ToInt32(columns[11]),
                        processed = Convert.ToInt32(columns[12]),
                        processed_date = Convert.ToDateTime(columns[13]),
                        systemuser_id = Convert.ToInt32(columns[14])
                    });
                }
            }
