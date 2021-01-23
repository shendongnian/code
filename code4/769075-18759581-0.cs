    List<object[]> entries = new List<Response.MapEntries>();
    using (IDbConnection db = Connection.Instance()) {
      db.Open();
      entries = db.Query<Response.MapEntries>(query.ToString(), parameters)
        .Select(e => new object[] { e.Id, e.Type_id, e.Latitude, e.Longitude })
        .ToList();
    }
    return entries;
