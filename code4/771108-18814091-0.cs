    class MyWorkerClass
    {
      public event EventHandler<System.ComponentModel.ProgressChangedEventArgs> Changed;
      
      void OnChanged(ProgressChangedEventArgs args)
      { 
         if (Changed != null) Changed(this, args);
      }
    
      public void DoWork(object state)
      {
         // do your work
         OnChanged(new ProgressChangedEventArgs(50, state);   // use percentage
      }
    }
