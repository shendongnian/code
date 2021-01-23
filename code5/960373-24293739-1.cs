    class ViewModel : INotifyPropertyChanged 
    {
        public ViewModel()
        {
              
            m_folders = new ObservableCollection<IFolder>();
    
            //add Root items
            Folders.Add(new Folder { FolderLabel = "Dummy1", FullPath = @"C:\dummy1" });
            Folders.Add(new Folder { FolderLabel = "Dummy2", FullPath = @"C:\dummy2" });
            Folders.Add(new Folder { FolderLabel = "Dummy3", FullPath = @"C:\dummy3" });
            Folders.Add(new Folder { FolderLabel = "Dummy4", FullPath = @"C:\dummy4" });
    
            //add sub items
            Folders[0].Folders.Add(new Folder { FolderLabel = "Dummy11", FullPath = @"C:\dummy11" });
            Folders[0].Folders.Add(new Folder { FolderLabel = "Dummy12", FullPath = @"C:\dummy12" });
            Folders[0].Folders.Add(new Folder { FolderLabel = "Dummy13", FullPath = @"C:\dummy13" });
            Folders[0].Folders.Add(new Folder { FolderLabel = "Dummy14", FullPath = @"C:\dummy14" });
    
        }
    
        public string TEST { get; set; }
    
    
        private ObservableCollection<IFolder> m_folders;
        public ObservableCollection<IFolder> Folders
        {
            get { return m_folders; }
            set
            {
                m_folders = value;
                NotifiyPropertyChanged("Folders");
            }
        }
    
        void NotifiyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
