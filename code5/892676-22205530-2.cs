    // Act
    var result = controller.Edit(testForm);
    // Assert
    var viewResult = result as ViewResult;
    Assert.That(viewResult, Is.Not.Null);
    
    var model = viewResult.Model as SiteViewModel;
    Assert.That(model, Is.Not.Null);
    // do your other assertions.
  
