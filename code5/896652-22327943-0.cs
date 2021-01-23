    try
            {
                SourceTable = new DataTable();
                
                SourceTable.Columns.AddRange(new DataColumn[]{
                    new DataColumn("TraderID", typeof(string)),
                    new DataColumn("TradeDate", typeof(DateTime)),
                    new DataColumn("TradeTime", typeof(TimeSpan)),
                    new DataColumn("ClientName", typeof(string)),
                    new DataColumn("CurPair", typeof(string)),
                    new DataColumn("Amnt", typeof(int)),
                    new DataColumn("Action", typeof(string)),
                    new DataColumn("ExecutedRate", typeof(decimal))
                });
                DataRow row = null;
                var OpenTradesQuery = from qa in connection.QuickAnalyzerInputs
                                      where qa.TradeClosedDateTime == null
                                      select new
                                      {
                                          qa.TraderID,
                                          qa.ClientTradedDate,
                                          qa.ClientTradedTime,
                                          qa.ClientName,
                                          qa.CurrencyPair,
                                          qa.TradedAmount,
                                          qa.Action,
                                          qa.ExecutedRate
                                      };
                
                if (OpenTradesQuery.Count() > 0)
                {
                    numOfrecords = OpenTradesQuery.Count();
                    DataContext = this;
                    foreach (var rowObj in OpenTradesQuery)
                    {
                        row = SourceTable.NewRow();
                        SourceTable.Rows.Add(rowObj.TraderID, rowObj.ClientTradedDate, rowObj.ClientTradedTime, rowObj.ClientName, rowObj.CurrencyPair, rowObj.TradedAmount, rowObj.Action, rowObj.ExecutedRate);
                    }
                }
                else
                {
                    MeBox.Show("You have no open trades.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            
            }
            catch
            {
                MeBox.Show("Error retrieving data.", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
