    class Communicator : CommunicationChannel<Client>
    {
      [CommunicationAspect]
      void Method1(args) 
      {
         client.Method1(args);
      }
      [CommunicationAspect]
      void Method2(args)
      {
         client.Method2(args);
      }
    }
