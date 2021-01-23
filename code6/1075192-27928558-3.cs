    class Presenter
    {
      public ObservableCollection<string> JustFake { get; set; }
    
      public Presenter() 
      {
         JustFake = new ObservableCollection<string> { "aaa", "bbb" };
      }
    }
