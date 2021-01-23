    private async Task<BitmapImage> ByteArrayToBitmapImage(byte[] byteArray)
    {
        var bitmapImage = new BitmapImage();
        var stream = new InMemoryRandomAccessStream();
        await stream.WriteAsync(byteArray.AsBuffer());
        stream.Seek(0);
        bitmapImage.SetSource(stream);
        return bitmapImage;
    }
    private ObservableCollection<BindingData> _rsMessages = new ObservableCollection<BindingData>();
    public ObservableCollection<BindingData> RSMessages
    {
        get { return _rsMessages; }
        set { _rsMessages = value; }
    }
    
    public async Task initializeListboxRS()
    {
        foreach (var items in UniDB.returnListOfRSItems())
        {
            _rsMessages.Add(new BindingData
            {
                rssMessageText = items.tile,
                rssMessageDateTime = items.dateTime.ToString("dd.MM.yyyy - hh:mm"),
                rssMessageImage = await ByteArrayToBitmapImage(items.image),
                rssMessageLink = items.link
            });
            OnPropertyChanged("RSMessages");
        }
    }
