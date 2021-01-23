    public static class SelectLists
    {
            public static IList<SelectListItem> CompanyClasses(int? selected)
            {
                var session = DependencyResolver.Current.GetService<ISession>();
    
                var list = new List<SelectListItem>
                               {
                                   new SelectListItem
                                       {
                                           Selected = !selected.HasValue,
                                           Text = String.Empty
                                       }
                               };
    
                list.AddRange(session.All<CompanyClass>()
                                  .ToList()
                                  .OrderBy(x => x.GetNameForCurrentCulture())
                                  .Select(x => new SelectListItem
                                                   {
                                                       Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                                       Text = x.GetNameForCurrentCulture(),
                                                       Value = x.Id.ToString()
                                                   })
                                  .ToList());
    
                return list;
            }
    }
