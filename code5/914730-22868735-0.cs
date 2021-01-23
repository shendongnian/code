    // create the mock for the view.
    var viewMock = new Mock<ICustomerSearchView>();
    
    // setup the property value
    viewMock.SetupGet(v => v.FromCustomerId).Returns("test");
    
    customerSearchPresenter.View = viewMock.Object; // the actual View.
