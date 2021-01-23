    public bool TryRunTransaction(Action transactionAction)
        {
            try
            {
                using (var transactionScope = new TransactionScope())
                {
                    transactionAction();
                    transactionScope.Complete();
                }
                return true;
            }
            catch (TransactionAbortedException)
            {
                return false;
            }
        }
