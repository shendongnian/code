    public IQueryable<vwBatchList> AggregateBatchList(int coid)
    {
         var contex = new LBPEntities();
         var batchList = contex.vwBatchLists.Where(x => x.CoId == coid).Select(x => new
                      {
                            CoId = x.CoId,
                            ...
                            BatchDetails = contex.vwBatchDetails.Where(d => d.BatchNumber == x.batchNumber)
                      });
         var result = Json(batchList);
    }
