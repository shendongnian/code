    void MyFunc(CancellationToken ct)
    {
      //...
      var timedOut = WaitHandle.WaitAny(new[] { ct.WaitHandle }, TimeSpan.FromMilliseconds(2000)) == WaitHandle.WaitTimeout;
      var cancelled = ! timedOut;
    }
