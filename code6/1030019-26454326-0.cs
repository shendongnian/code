    var _list = new List<vsk_error_log>();
    using (var entities = new vskdbEntities())
    {
        _list = entities.vsk_error_log
             .Where("added_date >= @0", DateTime.Now.AddDays(-1))
             .OrderBy(entity.Order)
             .Skip(entity.PageSize * (entity.PageNumber - 1))
             .Take(entity.PageSize)
             .ToList();
     }
     
    
