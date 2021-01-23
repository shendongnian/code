 using (var dataContext = new SchoolMSDbContext())
                {
                    using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        try
                        {
                            //your query
                            transaction.Complete();
                           
                        }
                        catch (Exception ex)
                        {
                            transaction.Dispose();
                            Console.WriteLine(ex.InnerException);
                        }
                    }
                }
