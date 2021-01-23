    FolderPicker folderPicker = new FolderPicker();
    folderPicker.SuggestedStartLocation = PickerLocationId.Desktop;
    folderPicker.ViewMode = PickerViewMode.List;
    folderPicker.FileTypeFilter.Add(".txt");
    folderPicker.PickFolderAndContinue();
