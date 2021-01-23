    public class MyEventArgs : EventArgs
    {
       public string MyEventData {get; set;}
    }
    public event EventHandler<MyEventArgs> MyEvent;
