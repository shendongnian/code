    public class classToConsume 
            {
              public void CreateMEFInstances()
               {
         
        
                  IClass objClassA = ObjectFactory.CreateObject<IClass>("TypeA");
                   IClass objClassB = ObjectFactory.CreateObject<IClass>("TypeB");
                }
            }
