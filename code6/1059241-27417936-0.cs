    List<StorageFile> fileList; // don't forget to initialize this somewhere!
    private async void addmusicbtn_Click(object sender, RoutedEventArgs e)
    {
            var fop = new FileOpenPicker();
            fop.FileTypeFilter.Add(".mp3");
            fop.FileTypeFilter.Add(".mp4");
            fop.FileTypeFilter.Add(".avi");
            fop.FileTypeFilter.Add(".wmv");
            fop.ViewMode = PickerViewMode.List;
            IReadOnlyList<StorageFile> pickedFileList;
   
            pickedFileList= await fop.PickMultipleFilesAsync();
            // add the picked files to our existing list
            fileList.AddRange(pickedFileList);
            // I'm not sure if you want fileList or pickedFileList here:
            foreach (StorageFile file in fileList)
            {
                mlist.Items.Add(file.Name);
                stream = await file.OpenAsync(FileAccessMode.Read);
                mediafile.SetSource(stream, file.ContentType);
            }
            mediafile.Play();
    }
