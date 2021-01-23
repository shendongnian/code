    public class MyViewModel : IHandle<MyEvent>
    {
       public MyViewModel(IEventAggregator eventAggregator) 
       {
          eventAggregator.Subscribe(this);
       }
       public void Handle(MyEvent message)
       {
          //Act on MyEvent
       }
    }
