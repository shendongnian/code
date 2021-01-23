    Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1)).
    Subscribe(o =>
    {
       // every second set current time on every item. 
       foreach(var item in YourCollection)
       {
        item.CurrentTime = DateTime.Now;
       }
    });
