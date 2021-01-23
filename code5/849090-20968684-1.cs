    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
    {
        FileInfo localFile = new FileInfo("localFile.txt");
        FileInfo pdfFile = new FileInfo("localFile.pdf");
        SimpleTransaction.EnlistTransaction(
            // prepare
            () =>
            {
                CreateTextFile(localFile);
                CreatePDFFile(pdfFile);
                // prepare mail should throw an error
                // if something is missing as sending email
                // is network operation, it cannot be rolled back
                // so email should be sent in commit
                PrepareMail();
            },
            // commit
            () =>
            {
                SendEmail();
            },
            // rollback
            () =>
            {
                try
                {
                    if (localFile.Exists)
                        localFile.Delete();
                    if (pdfFile.Exists)
                        pdfFile.Delete();
                }
                catch { }
            },
            // in doubt...
            () => { }
        );
    }
    public class SimpleTransaction : IEnlistmentNotification
    {
        public static void EnlistTransaction(Action prepare, Action commit, Action rollback, Action inDoubt)
        {
            var st = new SimpleTransaction(prepare, commit, rollback, inDoubt);
            Transaction.Current.EnlistVolatile(st, EnlistmentOptions.None);
        }
        Action CommitAction;
        Action PrepareAction;
        Action RollbackAction;
        Action InDoubtAction;
        private SimpleTransaction(Action prepare, Action commit, Action rollback, Action inDoubt)
        {
            this.CommitAction = commit;
            this.PrepareAction = prepare;
            this.RollbackAction = rollback;
            this.InDoubtAction = inDoubt  ?? (Action)(() => {});
        }
        public void Prepare(PreparingEnlistment preparingEnlistment)
        {
            try
            {
                PrepareAction();
                preparingEnlistment.Prepared();
            }
            catch
            {
                preparingEnlistment.ForceRollback();
            }
        }
        public void Commit(Enlistment enlistment)
        {
            CommitAction();
            enlistment.Done();
        }
        public void Rollback(Enlistment enlistment)
        {
            RollbackAction();
            enlistment.Done();
        }
        public void InDoubt(Enlistment enlistment)
        {
            InDoubtAction();
            enlistment.Done();
        }
    }
