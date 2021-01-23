    //set up a collection
       var xptos = new List<Xpto>() 
                { new Xpto() 
                { Sons = new List<Son> 
                    { new Son() { Names = "test1" },
                      new Son() { Names = "test2" } 
                    }
                },
              new Xpto() 
              {
                 Sons = new List<Son> {
                 new Son() { Names = "test3" } 
               }
               }};    
                
     //select the names
    var names = xptos.SelectMany(r => r.Sons).Where(k => k.Names != null)
               .Select(r => r.Names + ",") .ToList();
  
    names.ForEach(n => Console.WriteLine(n));
