    public static TransactionOptions GetTransactionOptions()
    {
        TransactionOptions tranOpt = new TransactionOptions();
        tranOpt.IsolationLevel = IsolationLevel.Serializable;
        return tranOpt;
    }
