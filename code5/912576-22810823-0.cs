    UIServicemock
        .Setup(u => u.ShowMessage(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<MessageBoxButton>(), It.IsAny<MessageBoxImage>()))
        .Callback<int, string, string, MessageBoxButton, MessageBoxImage>((window, message, error, button, image) => {
            Assert.That(message, Is.EqualTo("No cell selected"));
            Assert.That(window, Is.EqualTo(StudioViewName.MainWindow));
        });
