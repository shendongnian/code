    public static void Register(HttpConfiguration config)
    {
        var modelBuilder = new ODataConventionModelBuilder();
        modelBuilder.ContainerName = "EntityContainer";
        using(var ctx = new MyDBContext()) 
        {
            var dbSets = ctx.GetType().GetProperties();
            foreach(var set in dbSets)
            {
                if(set.PropertyType.IsGenericType)
                {
                     method = entitySet.MakeGenericMethod(set.PropertyType.GenericTypeArguments[0]);
                     bool containsEntity = false;
                     foreach (var entity in modelBuilder.EntitySets)
                     {
                         if (entity.GetType().Equals(set.PropertyType.GenericTypeArguments[0]))
                             containsEntity = true;
                       
                         if (!containsEntity)
                             method.Invoke(modelBuilder, new[] { set.Name });
                      } 
                 }
             }
         }
         _config.MapODataServiceRoute(
               routeName: "entities",
               routePrefix: API_ENTITIES_BASE_URI,
               model: modelBuilder.GetEdmModel()
               );
    }
