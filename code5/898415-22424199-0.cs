    private async void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
    {
        StorageFile pdf = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/irisclasson.pdf"));
    
        await
            Launcher.LaunchFileAsync(pdf,
                new LauncherOptions
                {
                    PreferredApplicationDisplayName = "PDF Touch",
                    PreferredApplicationPackageFamilyName = "162a2931-8ee6-4a56-9570-53282525d7a3",
                            
                    DisplayApplicationPicker = true,
                    DesiredRemainingView = ViewSizePreference.UseHalf
                });
    }
