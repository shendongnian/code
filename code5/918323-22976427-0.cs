    {                                                
          "$addToSet", new BsonDocument()
               {
                    { "items", new BsonDocument()
                         {
                              { "id", item.Id },
                              { "v", item.Value } 
                         }
                    }
               }
     }
