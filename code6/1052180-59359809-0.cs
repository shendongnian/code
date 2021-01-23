    public async Task<IHttpActionResult> GetUPSFreight(PartsExpressOrder order)
    {
        db.Entry(order).State = EntityState.Modified;
        db.SaveChanges();
      ...
    }
