    public class ViewModel:NotifyChange
    {
      private ObservableCollection<FileSystem> directories;
      public ObservableCollection<FileSystem> Directories
      {
        get
        {
            return directoriesField;
        }
        set
        {
            directoriesField = value;
            RaisePropertyChanged("Directories");
        }
      }
      public ViewModel()
      {
       //The below code has to be moved to thread for better user expericen since when UI is loaded it might not respond for some time since it is looping through all the drives and it;s directories
       Directories=new  ObservableCollection<FileSystem>();
       Directories.Add(new FileSystem("C:\\", null);
       Directories.Add(new FileSystem("D:\\", null);
       Directories.Add(new FileSystem("E:\\", null);
      }
    }
