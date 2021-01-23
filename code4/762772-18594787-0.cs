        public void OnException(ExceptionContext filterContext)
        {
            if (CurrentSessionContext.HasBind(SessionFactory))
            {
                var currentTransaction = CurrentSessionContext.Unbind(SessionFactory).Transaction;
                try
                {
                    if (currentTransaction.IsActive)
                        currentTransaction.Rollback();
                }
                finally
                {
                    currentTransaction.Dispose();
                }
            }
        }
