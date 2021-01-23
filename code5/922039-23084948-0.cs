    IObservable<string> textChanged = ...;
    IDisposable eventHandler = textChanged.Throttle(TimeSpan.FromMilliseconds(500))
                                  .Select(text => Observable.FromEvent((TaskCancelationToken cancel) => DoSearchTaskAsync(text, cancel)))
                                  .Switch()
                                  .Subscrible(results =>
                                  {
                                      //Update the UI
                                  });
