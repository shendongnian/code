    // TestHarness.cs
    [TestMethod]
    public void CheckDeactivation()
    {
        // We'd like to have the ToolViewerViewModel only Conduct the dock-able views 
        // and the DocViewerViewModel to conduct the DocumentViewModel.
        IViewModelFactory factory = new ViewModelFactory();
        DocViewerViewModel docViewer = new DocViewerViewModel(factory);
        IDockManager dockManager = null;
        var toolViewer = new ToolViewerViewModel(factory, docViewer, dockManager);
        var mockToolView = new UserControl();           
        (toolViewer as IViewAware).AttachView(mockToolView);
        DocumentViewModel docView1 = new NoDataViewModel();
        DocumentViewModel docView2 = new NoDataViewModel();
        docViewer.ActivateItem(docView1);
        docViewer.ActivateItem(docView2);
        Assert.AreEqual(0, docViewer.CountDeactivated());
    }
