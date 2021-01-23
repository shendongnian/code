    [TestMethod]
     public async Task Index()
    { 
      ....
       var result = await controller.Index();
       Assert.IsNotNull(result);
       var model = (List<Client>)((ViewResult)result).Model;
       Assert.AreEqual(2, model.Count())
     }
