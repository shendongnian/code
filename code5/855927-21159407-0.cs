    public class CardSweepedEventArgs {
    private readonly string _data;
    public string Data { get { return _data; } }
    
     public CardSweepedEventArgs(string data) {
    
      _data = data;
    
      }
    }
    public class YourReadinClass { 
    
    public EventHandler<CardSweepedEventArgs> CardSweeped; 
    
    // rest of logic.
    
    }
