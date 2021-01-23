    public IQueryable<vwBatchList> AggregateBatchList(int coid)
    {
         var contex = new LBPEntities();
         var batchList = contex.vwBatchLists.Where(x => x.CoId == coid).Select(x => new
                      {
                            CoId = x.CoId,
                            ...
                            BatchDetails = x.Details
                      });
         var result = Json(batchList);
    }
