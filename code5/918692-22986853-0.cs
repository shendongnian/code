      public IEnumerable<GlobalModel> GetDetails()
        {
            var models=(from po in dbEntity.SearchDetails.AsEnumerable()
                      select new GlobalModel()
                    {
                      IndexModel = new IndexModel(){
                         /* FromDate= po. FromDate,
                          ToDate= po. ToDate,*/
                          },
                      SearchModel = new SearchModel(){
                           /*SearchID = po.SearchID,
                           ReceivedDate = po.ReceivedDate,*/
                         },
                    }).ToList();
        }
