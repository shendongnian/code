    namespace Directories
    {
        private string ROOT = "root";
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
    
                DoSomething();
            }
    
            private void DoSomething()
            {
                CopyFolder(ROOT);
            }
    
            private async void CopyFolder(string path)
            {
                IStorageFolder Destination = Windows.Storage.ApplicationData.Current.LocalFolder;
                IStorageFolder root = Windows.ApplicationModel.Package.Current.InstalledLocation;
    
                if (path.Equals(ROOT) && !await FolderExistAsync(ROOT))
                    await Destination.CreateFolderAsync(ROOT);
                
                Destination = await Destination.GetFolderAsync(path);
                root = await root.GetFolderAsync(path);
    
                IReadOnlyList<IStorageItem> items = await root.GetItemsAsync();
                foreach (IStorageItem item in items)
                {
                    if (item.GetType() == typeof(StorageFile))
                    {
                        IStorageFile presFile = await StorageFile.GetFileFromApplicationUriAsync(
                            new Uri("ms-appx:///" + path.Replace("\\", "/") + "/" + item.Name));
    
                        await presFile.CopyAsync(Destination, item.Name);
                    }
                    else
                    {
                        if (!await FolderExistAsync(path + "\\" + item.Name))
                            await Destination.CreateFolderAsync(item.Name);
    
                        CheckFolder(path + "\\" + item.Name);
                    }
                }
            }
    
            private async Task<bool> FolderExistAsync(string foldername)
            {
                IStorageFolder Destination = Windows.Storage.ApplicationData.Current.LocalFolder;
    
                try
                {
                    await Destination.GetFolderAsync(foldername);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
