    var query = from p in _ctx.Table1
    join s in _ctx.Table2 on p.Id equals s.Id into bag1
    from to in bag1.DefaultIfEmpty()
    join tx in _ctx.Table3 on to.AId equals tx.Id into bag2
    from ts in bag2.DefaultIfEmpty()
    select new
    {
        ContactNo = to == null ? String.Empty  : to.Table1.ContactNo
    };
