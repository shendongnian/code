    public async Task<bool> pickPhoto()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.List;
            openPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            openPicker.FileTypeFilter.Add("*");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                BitmapImage image = new BitmapImage();
                image.SetSource(stream);
                imageChangedProfilePic.Source = image;
                imageChangedProfilePic.Stretch = Stretch.Fill;
                return true;
            }
            else
            {
                //  OutputTextBlock.Text = "Operation cancelled.";
                return false;
            }
        }
