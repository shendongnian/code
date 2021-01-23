    public class Listener
    {
      //declare a delegate for the event
      public delegate void InformationDelegate(DateTime timestamp);
   
      //declare the event using the delegate
      public event InformationDelegate Information;
      public void SomeFunction()
      {
        // do something...
        if(Information != null)
        {
          Information(DateTime.Now);
        }
      }
      // singleton handling etc... 
    }
