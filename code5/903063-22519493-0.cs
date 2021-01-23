    // Other code here...
    // Now update the collection in the UI Thread.  Use BeginInvoke if it needs to be Async
    Application.Current.Dispatcher.Invoke(
        new Action(() => 
            {
                 // Add to the collection here
                 foreach (object myObject in myObjects)
                 {
                     this.myCollection.Add(myObject);
                 }
            }));
    // Any other code needed here...
