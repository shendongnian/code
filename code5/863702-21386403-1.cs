         for(item in depenedents) 
     {
         context.GetMethod("Set")
             .MakeGenericType(Type.GetType(item))
             .Invoke(context, new object[0]);
         entities.GetType.GetMethod("GetGuid").Invoke(entities, new object[0]);
     }
