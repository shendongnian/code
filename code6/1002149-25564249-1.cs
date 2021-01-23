    public class PCQueue : IDisposable
    {
      BlockingCollection<Action<string>> _taskQ = new BlockingCollection<Action<string>>(); 
      //some code
    
      void Consume()
      {
        // This sequence that we’re enumerating will block when no elements
        // are available and will end when CompleteAdding is called. 
        foreach (Action<string> action in _taskQ.GetConsumingEnumerable())
          string param = GetCorrespondingParamFromArraySomeHow();
          action(param);     // Perform task.
      }
    }
