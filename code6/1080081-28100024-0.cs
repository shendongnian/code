    using (var ArgoEntities = new ARGOEntities())
            {
                //find the types here before the user performs the query so i can build the below code
                //Like this you can retrieve the types:
                foreach (string propertyName in ArgoEntities.CurrentValues.PropertyNames)
                {
                       var propertyInfo = ArgoEntities.Entity.GetType().GetProperty(propertyName);
                       var propertyType = propertyInfo.PropertyType;
                }
                //
                var query = from b in ArgoEntities.tbl_Books
                            where b.PublishDate>[user specified date]  //some date here the user enters
                            select b;
    
                var book = query.First();
            }
