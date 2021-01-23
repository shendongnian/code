    FileStream fileStream = new FileStream(sourceFilePath, FileMode.Open);
    
                try
                {
                    List<SalesHeader> result = new List<SalesHeader>();
                    dataSet.ReadXml(fileStream);
                    if (dataSet.Tables.Count> 0)
                    {
                        dataTable = dataSet.Tables[0];
                        if (dataTable != null)
                        {
    
                           for (int i = 0; i < dataTable.Rows.Count; i++)
                           {
                                SalesHeader salesHeader = new SalesHeader();
                                salesHeader.OutletCode = dataTable.Rows[i]["OutletCode"].ToString();
                                salesHeader.TransactionNo = dataTable.Rows[i]["TransactionNo"].ToString();
                                salesHeader.TransactionDate = Convert.ToDateTime(dataTable.Rows[i]["TransactionDate"]);
                                salesHeader.ShiftNo = Convert.ToInt16(dataTable.Rows[i]["ShiftNo"]);
                                salesHeader.TotalAmount = Convert.ToDecimal(dataTable.Rows[i]["TotalAmount"]);
                                salesHeader.TenderAmount = Convert.ToDecimal(dataTable.Rows[i]["TenderAmount"]);
                                salesHeader.ChangeAmount = Convert.ToDecimal(dataTable.Rows[i]["ChangeAmount"]);
                                salesHeader.TransactionStatus = Convert.ToInt16(dataTable.Rows[i]["TransactionStatus"]);
                                salesHeader.BusinessDate = Convert.ToDateTime(dataTable.Rows[i]["BusinessDate"]);
                                result.Add(saleshaeder);
                            }
                        }                           
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    fileStream.Close();
                }
