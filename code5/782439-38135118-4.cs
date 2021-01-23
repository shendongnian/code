    public static async Task<string> ShowMessageAsync()
    {
        // Set up a MessageDialog
        var popup = new Windows.UI.Popups.MessageDialog("Question", "Please pick a button to continue");
        popup.Commands.Add(new Windows.UI.Popups.UICommand("Button 1"));
        popup.Commands.Add(new Windows.UI.Popups.UICommand("Button 2"));
        popup.CancelCommandIndex = 0;
        // About to show the dialog
        Debug.WriteLine("Waiting for user choice...");
        var command = await popup.ShowAsync();
        // Dialog has been dismissed by the user
        Debug.WriteLine("User has made a choice. Returning result.");
        return command.Label;
    }
