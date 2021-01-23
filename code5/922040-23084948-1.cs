    var textChanged = Observable.FromEventPattern(x => textBox.TextChanged += x, x => textBox.TextChanged -= x)
                            .Select(_ => textBox.Text);
    IDisposable eventHandler = textChanged.Throttle(TimeSpan.FromMilliseconds(500))
                                  .Select(text => Observable.FromAsync((TaskCancelationToken cancel) => DoSearchTaskAsync(text, cancel)))
                                  .Switch()
                                  .Subscrible(results =>
                                  {
                                      //Update the UI
                                  });
