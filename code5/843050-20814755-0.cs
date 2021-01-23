    using Windows.Phone.Speech.VoiceCommands;
    // ...
    // Standard boilerplate method in the App class in App.xaml.cs
    private async void Application_Launching(object sender, LaunchingEventArgs e)
    {
        try // try block recommended to detect compilation errors in VCD file
        {
            await VoiceCommandService.InstallCommandSetsFromFileAsync(new Uri("ms-appx:///YourVCDFile.xml"));
        }
        catch (Exception ex)
        {
            // Handle exception
        }
    }
