    public interface IEventProvider //your IClassWithEvent
    {
       Event MyEvent...
    }
    
    public class EventResponder : IEventResponder
    {
       public void OnEvent(object sender, EventArgs args){...}
    }
    
    public class Boostrapper
    {
       public void WireEvent(IEventProvider eventProvider, IEventResponder eventResponder)
      {
          eventProvider>event += eventResponder.OnEvent;
      }
    }
