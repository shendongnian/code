    string selector = SmartCardReader.GetDeviceSelector();
    DeviceInformationCollection devices = await DeviceInformation.FindAllAsync(selector);
    foreach (DeviceInformation device in devices)
    {
        SmartCardReader reader = await SmartCardReader.FromIdAsync(device.Id);
        reader.CardAdded += ReaderOnCardAdded;
    }
    private static void ReaderOnCardAdded(SmartCardReader sender, CardAddedEventArgs args)
    {
        Task t = ReaderOnCardAddedAsync(sender, args);
        t.Wait();
    }
    private static async Task ReaderOnCardAddedAsync(SmartCardReader sender, CardAddedEventArgs args)
    {
        SmartCardProvisioning provisioning = await SmartCardProvisioning.FromSmartCardAsync(args.SmartCard);
    
        SmartCardStatus status;
        do
        {
            status = await provisioning.SmartCard.GetStatusAsync();
            Thread.Sleep(100);
        } while (status == SmartCardStatus.Shared);
    
        PrintCertificatesOrDoSomethingElseUseful();
    }
