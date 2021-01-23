    System.Reflection.MethodInfo mi = typeof(API).GetMethod("DoSomething", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    mi.MakeGenericMethod(typeof(Type.GetType(entityTypeName))).Invoke(new API(),new object[]{_db});
     class API
     {        
                 
         private void DoSomething<T>(DbContext db)
         {
           IQueryable<T> items = db.Set<T>();
          // Do something you need .....
         
         }
     }
