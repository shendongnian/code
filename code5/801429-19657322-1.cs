    private List<ListEmailItem> GetRequests(int topCount,bool reset = false)
            {
                List<ListEmailItem> items;
                using (var tran = new TransactionScope(
                    // a new transaction will always be created
                    TransactionScopeOption.RequiresNew,
                    // we will allow volatile data to be read during transaction
                    new TransactionOptions()
                    {
                        IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
                    }
                    ))
                {
                    using (var context = new IntegrationContext())
                    {
                        items = context.Database.SqlQuery<ListEmailItem>("Exec GetTopListEmailItems @topCount",
                            new SqlParameter("topCount", topCount)).Select(s => new ListEmailItem()
                            {
                                Id = s.Id,
                                Md5Hash = s.Md5Hash,
                                EmailAddress = s.EmailAddress,
    
                            }).ToList();
    
    
                    }
    
                    tran.Complete();
                }
    
                return items;
            }
