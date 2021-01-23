    public enum ItemStatus
     {
       Active = 1,
       Inactive = 2,
       Pending = 3
     }
      public IEnumerable<Items> getDate(params ItemStatus[] selectStatus)
        {       
          using (var context = new ItemsDBEntities())
          {
             return context.Items
                   .where(i=> selectStatus.Contains((ItemStatus)i.StatusID))
                            .select new Items()
                            {
                                Code = item.Code,
                                Name = item.Name
                            }).ToList();
            }         
        }
