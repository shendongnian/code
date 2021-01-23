    public class EventDispatcher<T> : where T : Event {
      public Dictionary<string, MyCallback<T>> eventTable = new Dictionary<string, MyCallback<T>>();
    
      void RegisterCallback(MyCallback<T> callback) {
        eventTable.Add("test", callback);
      }
    }
