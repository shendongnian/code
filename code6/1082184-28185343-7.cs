    class Transaction<T> : IOutputGenerator
    {
        // all as before
    }
    class TransactionFactory
    {
        public IOutputGenerator GetTransactionObject(string org)
        {
            if( typeClassLookup.TryGetValue(org, out typeValue))
            {
                switch (typeValue.ToString())
                {
                    case "policeData":
                        transactionObject = new Transaction<PoliceData>() { Data = new PoliceData(), params = null};
                    case "FireData":
                        transactionObject = new Transaction<FireData>() {Data = new FireData(), params = null};
                }
            }
            return transactionObject;
        }
    }
