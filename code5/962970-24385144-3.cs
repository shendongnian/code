    [Fact]
    public void RemoveAndNotify_RemovesItem()
    {   
        //Arrange
        var mockReceiver = ...
        var collection = new MyCollection<int>(mockReceiver.Object);
        collection.Add(5);
        //Act
        collection.Remove(5);
        //Assert
        //internally calls GetEnumerator to verify that the collection no longer contains "5"
        Assert.AreEqual(Enumerable.Empty<int>(), collection); 
    }
    [Fact]
    public void RemoveAndNotify_NotifiesReceiver()
    {   
        //Arrange
        var mockReceiver = ...
        var collection = new MyCollection<int>(mockReceiver.Object);
        collection.Add(5);
        //Act
        collection.Remove(5);
        //Assert
        mockReceiver.Verify(rec => rec.Notify(5), Times.Once());
    }
