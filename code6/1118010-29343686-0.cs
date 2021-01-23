     (from T in context.Transactions
      select new myModel
     {
        Amount = T.Amount,
        TenderType = context.TenderType.Where(x=>x.TransactionId==T.ID).FirstOrDefault()
     }).ToList();
