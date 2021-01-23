    //Create your context
    using(var ctx = new MyDbContext())
    {
        var items = ctx.Requests
            .GroupBy(r => new { r.RType.Name, r.RTypeID })
            .Select(r => new MyRequestData
                 {
                     Name = r.RType.Name,
                     Count = r.Count()
                 });
        return View(items);
    }
