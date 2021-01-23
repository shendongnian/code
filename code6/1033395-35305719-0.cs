     Nullable<DateTime> date=null;
     var entity = new Model()
                {
                    GoDate = date
                };
       DataContext.Models.Add(entity);
       DataContext.SaveChanges();
