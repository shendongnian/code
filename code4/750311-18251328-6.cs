    namespace Directories
    {
        private string ROOT = "root";
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
    
                CopyFolder(ROOT);
            }
    
            private async void CopyFolder(string path)
            {
                IStorageFolder destination = Windows.Storage.ApplicationData.Current.LocalFolder;
                IStorageFolder root = Windows.ApplicationModel.Package.Current.InstalledLocation;
    
                if (path.Equals(ROOT) && !await FolderExistAsync(ROOT))
                    await destination.CreateFolderAsync(ROOT);
                
                destination = await destination.GetFolderAsync(path);
                root = await root.GetFolderAsync(path);
    
                IReadOnlyList<IStorageItem> items = await root.GetItemsAsync();
                foreach (IStorageItem item in items)
                {
                    if (item.GetType() == typeof(StorageFile))
                    {
                        IStorageFile presFile = await StorageFile.GetFileFromApplicationUriAsync(
                            new Uri("ms-appx:///" + path.Replace("\\", "/") + "/" + item.Name));
    
                        // Do copy file to destination folder
                        await presFile.CopyAsync(destination);
                    }
                    else
                    {
                        // If folder doesn't exist, than create new one on destination folder
                        if (!await FolderExistAsync(path + "\\" + item.Name))
                            await destination.CreateFolderAsync(item.Name);
    
                        // Do recursive copy for every items inside
                        CopyFolder(path + "\\" + item.Name);
                    }
                }
            }
    
            private async Task<bool> FolderExistAsync(string foldername)
            {
                IStorageFolder destination = Windows.Storage.ApplicationData.Current.LocalFolder;
    
                try
                {
                    await destination.GetFolderAsync(foldername);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
