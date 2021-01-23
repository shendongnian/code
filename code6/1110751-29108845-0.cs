    public IQueryable<INV_AssetsHistory> GetHistoryByAssetId(int assetId)
    {
      var records = _dataContext.INV_AssetsHistory.Where
       (
          x => x.AssetId == assetId
       );
       return records;
    }
