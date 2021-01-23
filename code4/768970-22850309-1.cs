    // Prepare the values
    var allLines = (from trade in proposedTrades
                    select new object[] 
                    { 
                        trade.TradeType.ToString(), 
                        trade.AccountReference, 
                        trade.SecurityCodeType.ToString(), 
                        trade.SecurityCode, 
                        trade.ClientReference, 
                        trade.TradeCurrency, 
                        trade.AmountDenomination.ToString(), 
                        trade.Amount, 
                        trade.Units, 
                        trade.Percentage, 
                        trade.SettlementCurrency, 
                        trade.FOP, 
                        trade.ClientSettlementAccount, 
                        string.Format("\"{0}\"", trade.Notes),                             
                    }).ToList();
    // Build the file content
    var csv = new StringBuilder();
    allLines.ForEach(line => 
    {
        csv.AppendLine(string.Join(",", line));            
    });
    File.WriteAllText(filePath, csv.ToString());
