    public static List<Transaction> banksearch(string bankname, string sdate = null, string edate = null, string condition = null)
        {
            if (sdate == null && edate == null)//only bank
            {
               return transactions
                    .Where(t => t.BankName == bankname)
                    .Select(t => new Transaction
                     {
                         TransactionID = t.TransactionID,
                         BankName = t.BankName,
                         TemplateModel = t.TemplateModel,
                         Date = t.Date.ToString(),
                         PayeeName = t.PayeeName,
                         Amount = t.Amount.ToString()
                     }).ToList();
            } else {
               return new List<Transaction>();
           }
      }
