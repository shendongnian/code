    private ImageSource _image = null;
    private String _imagePath = null;
    public ImageSource Image
    {
        get
        {
            if (_image != null)
              return _image;
            if (_imagePath != null && !IsLoading)
              SetImageFromStorageFile().ContinueWith(OnAsyncFail, TaskContinuationOptions.OnlyOnFaulted);
            return null;
        }
    }
    private async Task SetImageFromStorageFile()
    {
        if (this.IsLoading)
          return;
        this.IsLoading = true;
        if (this._image == null && this._imagePath != null)
        {
                this._image = await BitmapLoader.GetPreviewImageFromStorageFile(this.StorageFile); //getting the actual data here
                this.OnPropertyChanged("Image");
        }
        this.IsLoading = false;
    }
