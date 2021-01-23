    private async void pickFolder(object sender, RoutedEventArgs e)
    {
  	    folderPicker = new FolderPicker();
        folderPicker.SuggestedStartLocation = PickerLocationId.Desktop;
	    folderPicker.ViewMode = PickerViewMode.List;
        folderPicker.FileTypeFilter.Add(".txt");
        StorageFolder folder = await folderPicker.PickSingleFolderAsync();
	    if(folder != null)
	    {
		     StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
	    }
}
