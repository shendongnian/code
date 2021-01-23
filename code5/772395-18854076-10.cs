    [TestMethod]
    public void IndexShouldNotReturnMoreThanPageSizeResults()
    {
        // arrange
        var controller = new ContactsController();
        
        // act
        var view = (ViewResult) controller.Index(10, 1);
      
        // assert  
        var Model = (IEnumerable<Contact>) view.Model;
        Assert.IsTrue(view.Model.Count() <= 10)
    }
