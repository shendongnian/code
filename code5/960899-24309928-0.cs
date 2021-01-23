    public class StateController : INotifyPropertyChanged
    {
      private static StateController instance;
      public static StateController Instance {
    	 get { return instance ?? (instance = new StateController()); }
      }
    
      //here`s our flag
      private bool isSomething;
      public bool IsSomething
      {
    	 get { return isSomething; }
    	 set
    	 {
    		isSomething = value;
    		PropertyChanged(this, new PropertyChangedEventArgs("IsSomething"));
    	 }
      }
    
      private StateController(){}
    
      public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
