    //// Act
    var result = controller.Edit(testForm);
    var viewResult = result as ViewResult;
    Assert.That(viewResult, Is.Not.Null);
    
    var model = viewResult.Model as SiteViewModel;
    Assert.That(model, Is.Not.Null);
    // do you other assertions.
  
