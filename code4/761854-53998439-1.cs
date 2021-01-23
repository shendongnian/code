    public static async Task<string> createDirectory(TextBox parmTextBox)
    {
        string folderName = parmTextBox.Text.Trim();
        // Section: Allows the user to choose their folder.
        FolderPicker fpFolder = new FolderPicker();
        fpFolder.SuggestedStartLocation = PickerLocationId.Desktop;
        fpFolder.ViewMode = PickerViewMode.Thumbnail;
        fpFolder.FileTypeFilter.Add("*");
        StorageFolder sfFolder = await fpFolder.PickSingleFolderAsync();
        if (sfFolder.Name != null)
        {
            // Gives the StorageFolder permissions to modify files in the specified folder.
            Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.AddOrReplace("CSharp_Temp", sfFolder);
            // creates our folder
            await sfFolder.CreateFolderAsync(folderName);
            // returns a string of our path back to the user
            return string.Concat(sfFolder.Path, @"\", folderName); 
        }
        else
        {
            MessageDialog msg = new MessageDialog("Need to choose a folder.");
            await msg.ShowAsync();
            return "Error: Choose new folder.";
        }
    }
