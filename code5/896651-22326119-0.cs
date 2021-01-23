    var OpenTradesQuery = (from qa in connection.QuickAnalyzerInputs
                                  where qa.TradeClosedDateTime == null
                                  select new TradesClass
                                  {
                                      TraderID = qa.TraderID,
                                      TradeDate = qa.ClientTradedDate,
                                      TradeTime = qa.ClientTradedTime,
                                      CloseDateTime = qa.TradeClosedDateTime,
                                      ClientName = qa.ClientName,
                                      CurPair = qa.CurrencyPair,
                                      Amnt = qa.TradedAmount,
                                      Action = qa.Action,
                                      ExecutedRate = qa.ExecutedRate
                                  }).ToList();
