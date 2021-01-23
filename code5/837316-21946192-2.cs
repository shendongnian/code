    _TestsService = _ComponentModel.GetService<Microsoft.VisualStudio.TestWindow.Extensibility.ITestsService>();
    var GetTestTask = _TestsService.GetTests();
    GetTestTask.ContinueWith(Task =>
    {
        var DiscoveredTests = Task.Results.ToList();
    });
