     using (var context = new YOUR-CONTEXT())
     {
          var toy = new Toy
          {
              productID = 1,   //Unique identifier                 
              AdultComments = new List<AdultComment>()
              {
                  new AdultComment { commentText = "Some comment" }
              }
           };
           context.Products.Add(toys);
           context.SaveChanges();
       }
            
