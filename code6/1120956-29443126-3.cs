    public List<CostYearModel> getResult() {
        var result = from ps in _context.PurchasingShipments
                             group ps by ps.date.Value.Year into grp
                             select new CostYearModel
                             {
                                 Year = grp.Key,
                                 Cost = grp.Sum(x => x.NoOfPieces * x.PricePerPiece + x.Micelleneous + x.TransportCost + x.SupplierCommission)
                             };
          return result.ToList();
    }
