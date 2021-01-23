    public static List<Transaction> banksearch(string bankname, string sdate = null, string edate = null, string condition = null)
    { 
    
        return transactions.Where(t => t.BankName == bankname && t.Date == startdate)
                           .Select(t => new Transaction() {
                                     TransactionID = t.TransactionID,
                                     BankName = t.BankName,
                                     TemplateModel = t.TemplateModel,
                                     Date = t.Date,
                                     PayeeName = t.PayeeName,
                                     Amount = t.Amount
                            }).ToList();
