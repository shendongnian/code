    using (var innerScope = new System.Transactions.TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }, EnterpriseServicesInteropOption.Full))
                {
                    try
                    {
                        // Do work here that causes an exception on first iteration only
                        if (i == 0)
                        {
                            throw new Exception(string.Format("Iteration {0} has FAILED", i));
                        }
                        else
                        {
                            outputStatus.Add("SUCCESS");
                        }
                    }
                    catch (Exception inner)
                    {
                        // Decide here if you want to bubble up the exception (and thus have all subsequent transactions fail. 
                    }
                }
