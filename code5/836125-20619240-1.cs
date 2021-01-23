    public enum ItemStatus   //in accordance with the Status Table
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
                   .where(item=> selectStatus.Contains((ItemStatus)item.StatusID))
                   .select new Items()
                    {
                     Code = item.Code,
                     Name = item.Name,
                     StatusID = item.StatusID 
                    }).ToList();
            }         
        }
