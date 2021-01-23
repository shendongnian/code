    ThreadStart start = delegate()
    {
      // make your calls to the db
    
      Dispatcher.Invoke(DispatcherPriority.Normal, 
                        new Action<object>(UpdateCollection), 
                        new object[] { myData });
    };
    new Thread(start).Start();
    
    private void UpdateCollection(object data)
    {
       //iterate your collection and add the data as needed
    }
