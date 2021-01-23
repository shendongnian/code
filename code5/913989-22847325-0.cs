    public TransactionCartItem GetTransactionCartItemByTransactionNumber(long transactionNumber)
    {   
        var query =
            this.ClientRepositories
                .Context
                .CreateQuery<TransactionCartItem>("GetTransactionCartItemByTransactionNumber")
                .AddQueryOption("transactionNumber", transactionNumber + "L")
                .FirstOrDefault();
    
        return query;
    }
