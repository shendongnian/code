    [TestMethod]
    public void AddT_HasBehaviorA() 
    {
        var mock = new Mock<IHelper<object>>();
        var sut = new Host<object>(mock.Object);
        var item = new object();
    
        sut.Add(item);
    
        mock.Verify(h => h.AddOrUpdate(item));
    }
    
    [TestMethod]
    public void UpdateT_HasBehaviorA() 
    { 
        var mock = new Mock<IHelper<object>>();
        var sut = new Host<object>(mock.Object);
        var item = new object();
    
        sut.Update(item);
    
        mock.Verify(h => h.AddOrUpdate(item));
    }
