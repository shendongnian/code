    using (var entities = new vskdbEntities())
    {
         entity.DataFields = "id, stack_trace";
         _list = entities.vsk_error_log
               .OrderBy(entity.Order)
               .Select("New(" + entity.DataFields + ")")
               .Skip(entity.PageSize * entity.PageNumber)
               .Take(entity.PageSize)
               .Select(x => new vsk_error_log 
               {
                   Property1 = x.Property1,
                   Property2 = x.Property2,
                   //etc...
               })
               .ToList();
    }
