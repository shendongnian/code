    [ServiceBehavior(
       InstanceContextMode = InstanceContextMode.Single, // required to hold the dictionary through calls
       ConcurrencyMode = ConcurrencyMode.Multiple] // let WCF run all the calls concurrently
    class Service
    {
      private readonly ConcurrentDictionary<int, object> _locks = new ConcurrentDictionary<int, object>();
    
      public void MyWcfOperation(int entityId, other arguments)
      {
         lock (_locks.GetOrAdd(entityId, i => new Object())
         {
           // do stuff with entity with id = entityId
         }
      }
    }
