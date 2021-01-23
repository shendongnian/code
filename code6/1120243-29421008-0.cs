    var bar1Mock = _kernel.GetMock<IBar();
    barMock1.Setup(m=>m.ContextType).Returns(ContextType.Site);
    var bar2Mock = _kernel.GetMock<IBar>(); 
    barMock2.Setup(m=>m.ContextType).Returns(ContextType.Local);
    var bar3Mock = _kernel.GetMock<IBar>(); 
    barMock3.Setup(m=>m.ContextType).Returns(ContextType.Test);
    
    // simply create new instance, what is a point o
    var target = new Foo(new[]{barMock1.Object, bar2Mock.Object, bar3Mock.Object });
