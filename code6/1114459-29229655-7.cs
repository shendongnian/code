    MessageBoxSettings settings = new MessageBoxSettings()
    {
        MessageDialogStyle = MessageDialogStyle.AffirmativeAndNegative,
        MetroColorDialogScheme = MetroDialogColorScheme.Accented,
        AffirmativeButtonText = "Delete",
        NegativeButtonText = "Cancel"
    };
    string message = String.Format(
        "Are you sure you want to delete back test \"{0}\" {1}",
        SelectedBackTest.Name,
        SelectedBackTest.LastRun == null ? 
            String.Empty : 
            String.Format("which was late run on {0:G}?", SelectedBackTest.LastRun));
    MessageDialogResult r = await dialogManager
        .ShowDialog<MessageDialogResult>(
            new MessageBoxViewModel("Confirm Delete", message, settings));
    if (r == MessageDialogResult.Affirmative)
    {
        ...
    }
    
