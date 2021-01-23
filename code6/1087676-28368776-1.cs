    public class Controller
    {
        Func<IService> _factory;
    public Controller(Func<IService> factory)
    {
       _factory = factory;
    }
    public Action DoSomethingManyTimes()
    {
      for(int i =0; i < numberOfTimes; i++)
      {
         Task.Factory.StartNew(() =>
         {  
            _factory().DoSomething();
         });
      }
    }
    }
