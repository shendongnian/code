    FolderPicker picker = new FolderPicker();
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".pdf");
            StorageFolder fold = await picker.PickSingleFolderAsync();
            StorageFile filey = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(ViewUri.Text);
            StorageFolder storageFolder = fold;
            try
            {
                await filey.CopyAsync(storageFolder);
                // let them know, done!
            }
            catch (System.UnauthorizedAccessException)
            {
                // an error occurred
            }
