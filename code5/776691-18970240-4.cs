    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Windows.Storage;
    using Windows.Storage.Search;
    
    namespace MyApp.Media
    {
        public class PictureRepository : INotifyPropertyChanged
        {
            #region Constants
    
            public const string IsolatedStoragePath = "Pictures";
    
            #endregion
    
            #region Fields
    
            private ObservableCollection<StorageFile> _pictures = new ObservableCollection<StorageFile>();
    
            #endregion
    
            #region Properties
    
            public ObservableCollection<StorageFile> Pictures
            {
                get { return _pictures; }
                private set
                {
                    RaisePropertyChanged("Pictures");
                    _pictures = value;
                }
            }
    
            #endregion
    
            #region INotifyPropertyChanged
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void RaisePropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            #endregion
    
            #region Singleton Pattern
            private PictureRepository()
            {
                // This call will warn that execution of the method will continue without waiting on completion
                // This is unimportant because the remainder of the constructor is not dependent on its initialization
                // and the UI will be notified of the change in the collection and respond at that time
                LoadAllPicturesFromIsolatedStorageAsync();
            }
            public static readonly PictureRepository Instance = new PictureRepository();
        
            #endregion
    
            /// <summary>
            /// To load all the pictures at start time
            /// </summary>
            private async Task LoadAllPicturesFromIsolatedStorageAsync()
            {
                // Create or open the target folder
                var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(IsolatedStoragePath, CreationCollisionOption.OpenIfExists);
    
                // Create a query for files with the JPEG extension
                var query = folder.CreateFileQueryWithOptions(new QueryOptions(CommonFileQuery.OrderByName, new string[] { ".jpg" }));
    
                // Update the Pictures collection, which will raise the PropertyChanged event and cause the UI to bind
                Pictures = new ObservableCollection<StorageFile>(await query.GetFilesAsync());
            }
        }
    }
