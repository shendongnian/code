    using (var dbContext = new ATMDbContext())
    {
        var currentAccount = dbContext.CardAccounts.FirstOrDefault(x => x.CardNumber == cardNumber);
        try
        {
            if (currentAccount == null)
            {
                  throw new ArgumentException("Invalid card number.");
            }
            if (currentAccount.CardPIN != cardPIN)
            {
               throw new ArgumentException("Invalid pin number.");
            }
            if (currentAccount.CardCash < money)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            currentAccount.CardCash -= money;
           var transactionLog = new TransactionHistory();
           transactionLog.CardNumber = cardNumber;
           transactionLog.TransactionDate = DateTime.Now;
           transactionLog.Ammount = money;
           dbContext.TransactionHistory.Add(transactionLog);
    
           dbContext.SaveChanges();
       }
       catch (Exception ex)
       {
          outputProvider.PrintLine(ex.Message);
       }
    }
