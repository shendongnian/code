    [TestMethod]
    public void ChildViewModelsCreatedTest()
    {
        var factory = new Mock<IViewModelFactory<IChildViewModel>>();
        factory.Setup(f => f.Create())
            .Returns(new List<IChildViewModel>() { new ChildViewModel() });
        var vm = new ChildrenViewModel(factory.Object);
        Assert.IsNotNull(vm.ChildViewModels);
        Assert.IsTrue(vm.ChildViewModels.Count == 1);
    } 
