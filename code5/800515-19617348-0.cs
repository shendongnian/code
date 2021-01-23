    public class MyEventArgs : System.EventArgs
    {
       public string EventData {get; private set;}
       public MyEventArgs(String argEventData)
       {
           EventData = argEventData;
       }
    }
