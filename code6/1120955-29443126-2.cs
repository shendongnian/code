    public List<Object> getResult() {
        var result = from ps in _context.PurchasingShipments
                             group ps by ps.date.Value.Year into grp
                             select (new
                             {
                                 Year = grp.Key,
                                 Cost = grp.Sum(x => x.NoOfPieces * x.PricePerPiece + x.Micelleneous + x.TransportCost + x.SupplierCommission)
                             } as Object);
        return result.ToList();
    }
