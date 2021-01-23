    var _list = new List<vsk_error_log>();
    using (var entities = new vskdbEntities())
    {
        var context = ((IObjectContextAdapter)entities).ObjectContext;
        var lst = context.CreateObjectSet<vsk_error_log>()
             .AsEnumerable()
             .Select("new(id,stack_trace)")
             .Cast<DynamicClass>()
             .Skip(entity.PageSize * (entity.PageNumber - 1))
             .Take(entity.PageSize)
             .ToList();
             foreach (dynamic d in lst)
             {
                 _list.Add(new vsk_error_log { id = d.id, stack_trace = d.stack_trace });
             }
    }
