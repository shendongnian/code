    public class OnFetchEvent : AsyncEvent {}
    public class OnDecodeEvent : AsyncEvent {}
    public class OnExecuteEvent : AsyncEvent {}
    public class OnWritebackEvent : AsyncEvent {}
    public class FetchObserver : Observer,
       IObserve<OnFetchEvent>
    {
       public void OnEvent(OnFetchEvent @event)
       {
          ....do some stuff
          // raise the next event
          RaiseEvent<OnDecodeEvent>(); 
       }
    }
    public class Pipeline
    {
       public void RaiseEvent<TEvent>()
       {
          if (typeof(TEvent) is AsyncEvent)
            ...create thread and raise the event which will notify the appropriate 
               observers of the event in the newly created thread
       }
      }
    
