    UIServicemock
        .Setup(u => u.ShowMessage(
            It.Is<int>(s => s == StudioViewName.MainWindow),
            It.IsIn<string>("No cell selected"),
            It.IsAny<string>(),
            It.IsAny<MessageBoxButton>(),
            It.IsAny<MessageBoxImage>()));
