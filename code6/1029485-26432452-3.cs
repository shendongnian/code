    using (var entities = new vskdbEntities())
    {
         _list = entities.vsk_error_log
               .OrderBy(entity.Order)
               .Select("it") // here "it"
               .Skip(entity.PageSize * entity.PageNumber)
               .Take(entity.PageSize)
               .ToList();
    }
