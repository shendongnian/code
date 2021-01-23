         public static void DefaultMappers(Assembly asm) 
         {
              foreach (Type t in asm.GetTypes())
              {
                  if (t.GetInterface(typeof (IDataObject).Name) != null)
                  {
                      BsonClassMap.LookupClassMap(t);
                      continue;
                  }
                  if (t.GetInterface(typeof(IDataMapped).Name) != null)
                  {
                      BsonClassMap.LookupClassMap(t);
                      continue;
                  }
              }
         }
