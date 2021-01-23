    var selectedItemOut = new Subject<int?>();
    // Hold the last result from the OnNext
    int? results = null;
    // idea: define some other IObservable or subject here
    // update var each time OnNext is called
    var lastResult = selectedItemOut.Subscribe(i => results = i);
    // just a wrapper around the results var.
    var getLatest = new Func<int?>(() => results);
    Assert.AreEqual(null, getLatest());
    selectedItemOut.OnNext(4);
    Assert.AreEqual(4, getLatest());
    selectedItemOut.OnNext(5);
    Assert.AreEqual(5, getLatest());
    selectedItemOut.OnNext(6);
    selectedItemOut.OnNext(7);
    Assert.AreEqual(7, getLatest());
    //Need to tell the observable to stop updating the results var.
    lastResultDispose.Dispose();
