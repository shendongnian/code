    public IQueryable<T> GetJoinedView<T>(Expression<Func<JoinedItem, T>> selector)
    {
        return DbContext.Set<TableA>()
                        .Join(DbContext.Set<TableB>(),
                              a => a.ID,
                              b => b.TableAID,
                              (ab) => new { A = a, B = b})
                        .Join(DbContext.Set<TableC>(),
                              ab => ab.B.ID,
                              c => c.TableBID
                              (ab, c) => new JoinedItem
                                  {
                                      TableA = ab.A,
                                      TableB = ab.B,
                                      TableC = c
                                  })
                         .Select(selector);
    }
