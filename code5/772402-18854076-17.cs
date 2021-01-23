    [TestMethod]
    public void IndexShouldNotReturnMoreThanPageSizeResults()
    {
        // arrange
        var factory = new MockUnitOfWorkFactory();
        var controller = new ContactsController(factory);
        
        // act
        var view = (ViewResult) controller.Index(10, 1);
      
        // assert  
        var Model = (IEnumerable<Contact>) view.Model;
        Assert.IsTrue(view.Model.Count() <= 10)
    }
