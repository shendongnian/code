    var @using = Observable.Using(
            () => new Res(),
            res => Observable.Return(res).Concat(Observable.Never<Res>()))
        .Publish((Res)null)
        .RefCount()
        .SkipWhile(res => res == null);
