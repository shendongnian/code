    public IEnumerable<IndexModel> GetDetails()
            {
                return (from po in dbEntity.SearchDetails
                          select new IndexModel()
                        {
                          SearchNumber = po.SearchNumber,
                          SearchID = po.SearchID,
                          ReceivedDate = po.ReceivedDate 
                        }).ToList();
    
            }
