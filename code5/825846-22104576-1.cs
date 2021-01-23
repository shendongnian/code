    [Serializable()]
    public class C3DGallery
    {
        public string Name { get; set; }
        public ObservableCollection<C3DGallery> ListItem { get; set; }
        public C3DGallery()
        {
            Name = "";
            ListItem = new ObservableCollection<C3DGallery>();
        }
    }
    [Serializable()]
    public class C3DGalleryFolder : C3DGallery
    {
        public C3DGalleryFolder(string sName)
        {
            Name = sName;
            ListItem = new ObservableCollection<C3DGallery>();
        }
    }
    [Serializable()]
    public class C3DGalleryItems : C3DGallery
    {
        public C3DGalleryItems()
        {
            Name = "";
            ListItem = new ObservableCollection<C3DGallery>();
        }
    }
    [Serializable()]
    public class C3DGalleryItem : C3DGallery
    {
        public string ImagePath { get; set; }
        public object Item { get; set; }
        public C3DGalleryItem(object oItem, string sName, string sImagePath)
        {
            Name = sName;
            ImagePath = "";
            Item = oItem;
            if (File.Exists(sImagePath)) { ImagePath = sImagePath; }
        }
    }
