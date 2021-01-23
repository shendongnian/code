    public class TransactionViewerViewModel : PropertyChangedBase
    {
      public ObservableCollection<Session> SessionList { get; set; }
      public string Test{ get; set; }
    
      public TransactionViewerViewModel()
      {
         SessionList = new ObservableCollection<Session>();
    
         SessionList.Add(new Session() { BeginLine = 0, EndLine = 1, Message = "some message" });
         SessionList.Add(new Session() { BeginLine = 2, EndLine = 3, Message = "another message" });
    
      }
    
      public void AddTest()
      {
         SessionList.Add(new Session() { BeginLine = 4, EndLine = 5, Message = Test });
      }
    }
