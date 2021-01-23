    string expectedResourceString = /* whatever you expect */;
    UIServicemock.Verify(u => u.ShowMessage(StudioViewName.MainWindow, 
                                            "No cell selected",
                                            expectedResourceString,
                                            MessageBoxButton.OK, 
                                            MessageBoxImage.Error));
