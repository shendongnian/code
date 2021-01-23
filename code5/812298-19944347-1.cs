    private ImageSource _image = null;
    private String _imagePath = null;
    public ImageSource Image
    {
        get
        {
            if (_image != null)
              return _image;
            if (_imagePath != null && !IsLoading)
              SetImageFromStorageFile();
            return null;
        }
    }
    private async Task SetImageFromStorageFile()
    {
        if (this.IsLoading || this._image != null || this._imagePath == null)
          return;
        this.IsLoading = true;
        try
        {
          this._image = await BitmapLoader.GetPreviewImageFromStorageFile(this.StorageFile); //getting the actual data here
          this.IsLoading = false;
          this.OnPropertyChanged("Image");
        }
        catch 
        {
          OnAsyncFail();
        }
    }
