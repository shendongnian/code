     [Transaction] // will apply the TransactionFilter to each action in this controller
     public DoAllTheThingsController : ApiController
     {
         private ISession _session;
         
         public DoAllTheThingsController(ISession session)
         {
               _session = session; // we're assuming here you've set up an IoC to inject the Isession from the dependency scope, which will be the same as the one we saw in the filter
         }
         [HttpPost]
         public TheThing Post(TheThingModel model)
         {
              var thing = new TheThing();
              // omitted: map model to the thing.
             
              // the filter will have created a session and ensured a transaction, so this all nice and safe, no need to add logic to fart around with the session or transaction. if an error occurs while saving, the filter will roll it back.
              _session.Save(thing);
             return thing;
         }
     }
