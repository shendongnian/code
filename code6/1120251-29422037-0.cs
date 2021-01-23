    var bar1Mock = _kernel.GetMock<IBar();barMock1.Setup(m=>m.ContextType).Returns(ContextType.Site);
    _kernel.Reset();
    var bar2Mock = _kernel.GetMock<IBar>();barMock2.Setup(m=>m.ContextType).Returns(ContextType.Local);
    _kernel.Reset();
    var bar3Mock = _kernel.GetMock<IBar>(); barMock3.Setup(m=>m.ContextType).Returns(ContextType.Test);
