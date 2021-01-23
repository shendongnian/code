    [TestMethod]
    public void CheckDeactivation()
    {
        var viewModelFactory = new DummyViewModelFactory();
        
        viewModelFactory.RegisterCreatorFor<NoDataViewModel>(() => new NoDataViewModelMock());
        
        var docViewer = new DocViewerViewModel(viewModelFactory);
        IDockManager dockManager = null;
         
        var toolViewer = new ToolViewerViewModel(viewModelFactory, docViewer, dockManager);
        var mockToolView = new UserControl();
        (toolViewer as IViewAware).AttachView(mockToolView);
        
        docViewerViewModel.ShowInMainView<NoDataViewModel>();
        docViewerViewModel.ShowInMainView<NoDataViewModel>();
        docViewerViewModel.ShowInMainView<NoDataViewModel>();
         
        Assert.AreEqual(3, NoDataViewModelMock.ActivationCounterForTesting);
        Assert.AreEqual(2, NoDataViewModelMock.DeactivationCounterForTesting);
    }
