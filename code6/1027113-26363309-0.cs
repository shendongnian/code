    var firstCall = false;
    mockBackOffice.Setup(x => x.Buy(It.IsAny<string>(), It.IsAny<int>()))
                  .Callback((string stock, int amount) => {
                      if (firstCall)
                          firstCall = false;
                      else
                          throw new InvalidOperationException("second call");
                  });
