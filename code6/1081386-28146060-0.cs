    FolderPicker openFP = new FolderPicker();
    openFP.ViewMode = PickerViewMode.Thumbnail;
    openFP.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
    openFP.FileTypeFilter.Add(".jpeg");
    openFP.FileTypeFilter.Add(".gif");
    openFP.FileTypeFilter.Add(".png");
    StorageFolder SF = await openFP.PickSingleFolderAsync();    StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", SF);
    this.Frame.Navigate(typeof(MainPage), SF.Name);
