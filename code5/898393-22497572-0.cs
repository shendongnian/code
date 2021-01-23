    public class DriveExplorer
    {
        private ObservableCollection<Folder> _folders;
        public ObservableCollection<Folder> Folders
        {
            get
            {
                _folders = new ObservableCollection<Folder>();
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    //We only want drives with folders, "Fixed" is hard drives
                    if (drive.DriveType == DriveType.Fixed)
                    {
                        Folder newFolder = new Folder();
                        newFolder.FullPath = drive.Name;
                        _folders.Add(newFolder);
                    }
                }
            }
        }
    }
