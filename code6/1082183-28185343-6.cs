    class TransactionFactory
    {
        public Transaction<T> GetTransactionObject<T>()
            where T : IDepartmentEntity, new()
        {
            return new Transaction<T>()
            {
                Data = new T(),
                params = null
            }
        }
    }
