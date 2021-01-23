    var mockFooClassProvider = new Mock<IFooClassProvider>();
    var mockMyContainerProvider = new Mock<MyContainerProvider>();
    var myKnownContainer = new MyContainer(...);
    mockMyContainerProvider.Setup(m => m.CreateMyContainer(It.IsAny<int>, ...))
        .Returns(myKnownContainer);
    var myClass = new MyClass(mockMyContainerProvider.Object, mockFooClassProvider.Object);
    FooClass fooClass;
    myClass.MyMethod(..., out fooClass);
    mockFooClassProvider.Verify(m => m.CreateFooClass(myKnownContainer, It.IsAny<int>(),...);
