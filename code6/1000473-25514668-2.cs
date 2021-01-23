    using (db)
                {
                    foreach (var transaction in corpCardTransaction)
                    {
                        var entity = new CorpCardTransaction
                        {
                            ID = transaction.ID,
                            Description = transaction.Description,
                            GL_Account = transaction.GL_Account,
                            BranchCode = transaction.BranchCode,
                            Receipt = transaction.Receipt
                        };
                        db.CorpCardTransactions.Add(entity);
                        db.SaveChanges();
                    }
                }
