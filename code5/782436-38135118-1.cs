    public static async Task<string> ShowMessageAsync()
    {
        var popup = new Windows.UI.Popups.MessageDialog("Question", "Please pick a button to continue");
        popup.Commands.Add(new Windows.UI.Popups.UICommand("Button 1"));
        popup.Commands.Add(new Windows.UI.Popups.UICommand("Button 2"));
        popup.CancelCommandIndex = 0;
        Debug.WriteLine("Waiting for user choice...");
        var command = await popup.ShowAsync();
        Debug.WriteLine("User has made a choice. Returning result.");
        return command.Label;
    }
