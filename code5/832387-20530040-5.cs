    // Some basic Window settings.
    dynamic settings = new ExpandoObject();
        settings.Title = "Test Window";
        settings.WindowStartupLocation = WindowStartupLocation.Manual;
        settings.SizeToContent = SizeToContent.Manual;
        settings.Width = 450;
        settings.Height = 300;
        var TestViewModel new TestViewModel();
        WindowManagerFactory.WindowManager.ShowWindow(this.classSearch, null, settings);
