     var bar1Mock = _kernel.GetMock<IBar();
     barMock1.Setup(m=>m.ContextType).Returns(ContextType.Site);
     var bar2Mock = _kernel.GetMock<IBar>(); 
     barMock2.Setup(m=>m.ContextType).Returns(ContextType.Local);
     var bar3Mock = _kernel.GetMock<IBar>(); 
     barMock3.Setup(m=>m.ContextType).Returns(ContextType.Test);
    _kernel.Bind<IBar>().ToConstant(bar1Mock.Object); 
    _kernel.Bind<IBar>().ToConstant(bar2Mock.Object);
    _kernel.Bind<IBar>().ToConstant(bar3Mock.Object);
    
    foo = _kernel.Get<IFoo>();
