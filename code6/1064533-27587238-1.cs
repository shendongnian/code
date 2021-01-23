    private async void UpdateInformationSection(IUICommand command) {
        InformationModel GeneralInformationModel = new InformationModel
    {
        apistatus = await voip_service.isAPIEnabled(),
        apimessage = await voip_service.GetAPIMessage(),
        currentbalance = await voip_service.getBalance(),
        currentip = await voip_service.getIP()
    };
    if (GeneralInformationModel.apistatus == false) {
        var msgdialog = new MessageDialog(
            "Please go to voip.ms to enable your API. You will need to know the IP address of the device on which this application is installed",
            "API connection could not be established");
        // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
        msgdialog.Commands.Add(new UICommand("Try again"));
        // Show the message dialog
        await msgdialog.ShowAsync();
        var _ = CoreWindow.GetForCurrentThread().Dispatcher
            .RunAsync(CoreDispatcherPriority.Normal,
                () => { var ignoreTask = UpdateInformationSection(command); });
        return;
    }
    // set the data context for the first section of the hub
    // so we can use bindings.
    mainpagehub.Sections[0].DataContext = GeneralInformationModel;
