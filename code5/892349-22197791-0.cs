    public IList GetReferenceData(Type type, TransactionManager transactionManager = null)
    {
       // ...
    }
    
    private IList GetReferenceDataNoCache(Type type, TransactionManager transactionManager = null)
    {
       // ...
    }
    
    public IList<T> GetReferenceData<T>(TransactionManager transactionManager = null)
    {
        return (IList<T>)GetReferenceData(typeof(T), transactionManager);
    }
