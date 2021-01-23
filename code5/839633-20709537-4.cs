    var observable = Observable.Create<string>(async observer =>
    {
        var wc = new WebClient { UseDefaultCredentials = true };
        observer.OnNext(await wc.DownloadStringTaskAsync("http://ya.ru"));
    });
    observable
        .Concat(Observable.Empty<string>().Delay(TimeSpan.FromSeconds(1)))
        .Repeat()
        .Subscribe(
          res => Debug.WriteLine("got result: {0}", res), 
          exc => Debug.WriteLine("exception: {0}", exc.Message)
        ); 
