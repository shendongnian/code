    string message = "Test message.";
    string caption = "RTL Test";
    MessageBoxImage image = MessageBoxImage.Information;
    MessageBoxButton button = MessageBoxButton.OK;
    MessageBoxResult defaultResult = MessageBoxResult.OK;
                
    MessageBox.Show(message, caption, button, image, defaultResult, MessageBoxOptions.RightAlign);
    MessageBox.Show(message, caption, button, image, defaultResult, MessageBoxOptions.RtlReading);
    MessageBox.Show(message, caption, button, image, defaultResult, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
