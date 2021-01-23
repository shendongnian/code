    class Latest
    {
        public string ThumbLink { get; set; }
        public BitmapImage Thumb { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public async Task<bool> LoadThumbAsync()
        {
            WebClient client = new WebClient();
            client.OpenReadAsync(new Uri(this.ThumbLink));
            client.OpenReadCompleted += (s, e) => //Wait for completion
            {
                var tempBitmap = new BitmapImage(); //Create temp bitmap container
                tempBitmap.SetSource(e.Result); //Copy stream to bitmap container
                this.Thumb = tempBitmap;
                e.Result.Close();
                return;
            };
            return true; // return bool only to be able to await this method.
        }
    }
    class ViewModel
    {
        ObservableCollection<Latest> lastdownloaded = new ObservableCollection<Latest>();
        ObservableCollection<Latest> allItems = new ObservableCollection<Latest>();
        public async void LoadData()
        {
            //Here you load all your thumbs in list allItems. This is only temporary container.
            for (var i = 0; i < allItems.Count; i++) // Now here for every item in that container you load thumb and add it to lastdownloaded list which you bind to Long List Selector.
            {
                await allItems[i].LoadThumbAsync();
                lastdownloaded.Add(allItems[i]);
            }
        }
    }
