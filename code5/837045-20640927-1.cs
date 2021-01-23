    public static List<SelectListItem> GetLookupData(string lookupType)
        {
           MPPEntities dbContext = new MPPEntities();
           return (from c in dbContext.SystemLookups
                        where c.lookup_type == lookupType
                        orderby c.order_by
                        select new SelectListItem { Text = c.name, Value = c.value })
                        .ToList();
        }
