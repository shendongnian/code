      Observable.Interval(TimeSpan.FromSeconds(2))
        .Select(_ => 
          Directory.GetFiles(path, filter)
         .ToObservable()
         .Select(s => new FileChangedEvent(s, @"Existing"))
       )
       .SelectMany(_ => _)
       .Subscribe(onNewFileChangedEvent => {
         Console.WriteLine(onNewFileChangedEvent.ToString());
       });
