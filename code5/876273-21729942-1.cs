    var xx = DbContext.Set<Article>()
          .Where(x=>x.Name.Contains("X"))
          .Select(x=> new 
            {
               Article = x,
               orderItem = SqlFunction.//Any function you want to use.
                                       // Or may you want to use DbFunctions               
            })
          .OrderBy(x=>x.orderItem);
