    private async void imgDone_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            // disable click event so it won't fire as well
            lvwCouncils.IsItemClickEnabled = false;
            // do stuff
            MessageDialog m = new MessageDialog("User Details");
            await m.ShowAsync();
            // Re-enable the click event
            lvwCouncils.IsItemClickEnabled = true;
        }
