    var groups = Observable.Create(o => {
        var publishedSource = source.Publish();
        return new CompositeDisposable(
            publishedSource.Buffer(publishedSource.Where(c => c == ';')).Subscribe(o),
            publishedSource().Connect()
            );
    });
