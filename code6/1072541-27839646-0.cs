                    IQueryable<Account> query1 = from account in storage.Accounts
                                                 where account.Username == username
                                                 select account;
                    IQueryable<SomeNewTypeIfNecessary> query2 = from account in query1
                                                                where account.ID > 100
                                                                select new SomeNewTypeIfNecessary { ID = account.ID };
                    // Final call doing real query to database.
                    List<SomeNewTypeIfNecessary> accounts = query2.ToList();
