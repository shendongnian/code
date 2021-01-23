using System.Reactive.Threading.Tasks;
    var observable = Observable.Using(() => new WebClient(), (client) =>
        client.DownloadStringTaskAsync("http://ya.ru")
            .ToObservable()
            .Concat(Observable.Empty<string>().Delay(TimeSpan.FromSeconds(1)))
            .Repeat()
            );
