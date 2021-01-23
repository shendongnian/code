       public LocalProxy:ICalculator //this will use direct instance of the Calculator Service
       {
          private ICalculator _calculator
    
          public  LocalProxy(ICalculator calculator)
          {
            _calculator =calculator;
          }
       
          public int Add(int x, int y)
          {
             return _calculator.Add(x,y);
          }
      
    }
   
     public class RemoteProxy:ICalculator  ///This will be real wcf proxy
        
        {
          
        
           public int Add (int x,int y)
           {
             
              var endpointAddress = new EndpointAddress(EndpointUrl);
               ChannelFactory<ICalculator> factory = null;
               ICalculator calculator ;
        
              try
              {
                 // Just picking a simple binding here to focus on other aspects
                 Binding binding = new BasicHttpBinding();
        
                 factory = new ChannelFactory<ICalculator>(binding);
                 calculator= factory.CreateChannel(endpointAddress);
                 if (calculator== null)
                 {
                     throw new CommunicationException(
                        String.Format("Unable to connect to service at {0}", endpointUrl));
                 }
        
                 int sum= calculator.Add(x,y);
                 ((IClientChannel)calculator).Close();
        
                 calculator = null;
                 factory.Close();
                 factory = null;
        
                 return sum;
              }
              finally
              {
                 if (calculator!= null) ((IClientChannel)calculator).Close();
                 if (factory != null) factory.Abort();
              }
           }
           
        }
          
