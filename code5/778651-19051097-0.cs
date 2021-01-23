    ....
    public void ProcessData(ISource source)
    {
       source.Counter ++;
    }
    
    ...
    [Test]
    .....
    
    sut.DoWork();
    var countBeforeEvent = source.Count;
    mockSource.Raise(s => s.DataChanged += null, new DataChangedEventArgs(fooValue));
    Assert.AreEqual(countBeforeEvent, source.Count);
