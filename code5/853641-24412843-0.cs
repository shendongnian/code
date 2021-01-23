    public abstract class TransactionCreator : IEnlistmentNotification
    {
        protected TransactionCreator()
        {
            System.Transactions.Transaction.Current.EnlistVolatile(this, EnlistmentOptions.None);
        }
        public void Commit(Enlistment enlistment)
        {
            Complete();
            enlistment.Done();
        }
        public void InDoubt(Enlistment enlistment)
        {
            enlistment.Done();
        }
        //Don't throw an exception here. Instead call ForceRollback()
        public void Prepare(PreparingEnlistment preparingEnlistment)
        {
            try
            {
                Execute();
                preparingEnlistment.Prepared();
            }
            catch (Exception e)
            {
                preparingEnlistment.ForceRollback(e);
            }
        }
        public void Rollback(Enlistment enlistment)
        {
            Revert();
            enlistment.Done();
        }
        public abstract void Execute();
        public abstract void Complete();
        public abstract void Revert();
    }
