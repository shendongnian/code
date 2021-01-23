    static SortedList<int, ManualResetEvent> MyManualEventList 
           = new SortedList<int, ManualResetEvent>();
      public EventHolder() { Signaler.SignalMyManualEvent 
           += OnSignalMyManualEvent; }
      void OnSignalMyManualEvent(int listindex)
      {
        
