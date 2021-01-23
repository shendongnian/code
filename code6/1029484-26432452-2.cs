    var result = new List<vsk_error_log>();
    using (var entities = new vskdbEntities())
    {
        _list = entities.vsk_error_log
               .OrderBy(entity.Order)
               .Skip(entity.PageSize * entity.PageNumber)
               .Take(entity.PageSize)
               .Select("new (id, stack_trace)");
            
        foreach(dynamic d in _list)
        {
            result.Add(new vsk_error_log { id = d.id, stack_trace = d.stack_trace } );
        }
    }
