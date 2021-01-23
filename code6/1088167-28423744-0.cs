        public void DownloadFiles(Uri url)
        {
           
            var wc = new WebClient();
            wc.OpenReadCompleted +=async (s, e) =>
            {
                Stream st = e.Result;
                buf = ReadFully(st);
                FileSavePicker savePicker = new FileSavePicker();
                savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                // Dropdown of file types the user can save the file as
                savePicker.FileTypeChoices.Add("PDF", new List<string>() { ".pdf" });
                // Default file name if the user does not type one in or select a file to replace
                savePicker.SuggestedFileName = "New Document";
                savePicker.PickSaveFileAndContinue();
                StorageFile SF = await KnownFolders.PicturesLibrary.CreateFileAsync
                          ("Guide.pdf", CreationCollisionOption.ReplaceExisting);
                var fs = await SF.OpenAsync(FileAccessMode.ReadWrite);
                StorageStreamTransaction transaction = await SF.OpenTransactedWriteAsync();
                DataWriter dataWriter = new DataWriter(transaction.Stream);
                dataWriter.WriteBytes(buf);
                transaction.Stream.Size = await dataWriter.StoreAsync(); // reset stream size to override the file
                await transaction.CommitAsync();
            };
            wc.OpenReadAsync(url);
            
        }
      public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
       private async void ContinueFileOpenPicker(FileSavePickerContinuationEventArgs args)
        {
            StorageFile file = args.File;
            if (file != null)
            {
                // Prevent updates to the remote version of the file until we finish making changes and call CompleteUpdatesAsync.
                CachedFileManager.DeferUpdates(file);
                // write to file
                await FileIO.WriteBytesAsync(file, buf);
                // Let Windows know that we're finished changing the file so the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(file);
                if (status == FileUpdateStatus.Complete)
                {
                    Debug.WriteLine("File " + file.Name + " was saved.");
                }
                else
                {
                    Debug.WriteLine("File " + file.Name + " couldn't be saved.");
                }
            }
            else
            {
                Debug.WriteLine("Operation cancelled.");
            }
            await Windows.System.Launcher.LaunchFileAsync(file);
        }
