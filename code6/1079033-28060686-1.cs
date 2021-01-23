    public class ContactModel
    {
        // constructor
        public ContactModel()
        {
            Name = "name";
            Albumart = new BitmapImage(new Uri("ms-appx:///Assets/Logo.scale-240.png"));
        }
        public async static Task<ObservableCollection<ContactModel>> CreateSampleData()
        {
            ObservableCollection<ContactModel> data = new ObservableCollection<ContactModel>();
            IReadOnlyList<IStorageItem> MusicLibrary = await KnownFolders.MusicLibrary.GetFoldersAsync(CommonFolderQuery.GroupByAlbum);
            foreach (IStorageItem item in MusicLibrary)
            {
                ContactModel obj = new ContactModel();
                IStorageItem musicItem = item;
                obj.Name = musicItem.Name;
                obj.Albumart = new BitmapImage(new Uri("ms-appx:///Assets/Logo.scale-240.png"));
                data.Add(obj);
            }
            return data;
        }
        public string Name { get; set; }
        public ImageSource Albumart { get; set; }
    }
