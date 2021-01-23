        private async void btnGetLocalFolder_Click(object sender, RoutedEventArgs e)
        {
            // The code for this event handler has been refactored into a method
            // because it is called from multiple event handlers.
            await ListFilesInLocalFolderAsync();
        }
        private async void btnCreateFile_Click(object sender, RoutedEventArgs e)
        {
            // Create a new file with a random filename.
            string newFilePath = Path.GetTempFileName();
            string newFileName = Path.GetFileName(newFilePath);
            StorageFile newFile = await localFolder.CreateFileAsync(newFileName, CreationCollisionOption.ReplaceExisting);
            
            // Save the new file in the list of files created by this app.
            thisApp.filesToDelete.Add(newFile.Path);
            // Enumerate the files and folders in the local folder,
            // including the new file.
            await ListFilesInLocalFolderAsync();
        }
        private async void btnCreateFolder_Click(object sender, RoutedEventArgs e)
        {
            // Create a new folder with a default folder name.
            const string folderName = NEW_FOLDER_NAME;
            StorageFolder newFolder = await localFolder.CreateFolderAsync(folderName, CreationCollisionOption.ReplaceExisting);
            
            // Save the new folder in the list of folders created by this app.
            thisApp.foldersToDelete.Add(newFolder.Path);
            // Enumerate the files and folders in the local folder,
            // including the new folder.
            await ListFilesInLocalFolderAsync();
        }
        private async void btnWriteTextFile_Click(object sender, RoutedEventArgs e)
        {
            string textFilePath = await FileHelper.WriteTextFile(TEXT_FILE_NAME, AppResources.TextFileContent);
            // Save the new file in the list of files created by this app.
            thisApp.filesToDelete.Add(textFilePath);
            // Enumerate the files and folders in the local folder,
            // including the new file.
            await ListFilesInLocalFolderAsync();
        }
