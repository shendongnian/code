    private async void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
    {
        e.Handled = true;
        var msg = new MessageDialog("Confirm Close");
        var okBtn = new UICommand("OK");
        var cancelBtn = new UICommand("Cancel");
        msg.Commands.Add(okBtn);
        msg.Commands.Add(cancelBtn);
        IUICommand result = await msg.ShowAsync();
    }
