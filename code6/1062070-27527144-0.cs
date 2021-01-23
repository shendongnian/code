    foreach (DataRow row in LiqTbl.Rows)
                    {
                        if (row.ItemArray[0].Equals(timezone))
                        {
                            foreach (DataColumn column in LiqTbl.Columns)
                            {
                                if (column.ColumnName.Equals(lp))
                                {
                                    //Write the value in the corresponding row
                                    row[column] = liq.ToString("N", CultureInfo.InvariantCulture);
                                }
                            }
                        }
                    }
