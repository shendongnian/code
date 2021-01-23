    public class FileSystem :NotifyChange, IEnumerable
    {
    #region Private members
    private ObservableCollection<FileSystem> subDirectoriesField;
    #endregion
    #region Public properties
    /// <summary>
    /// Gets and sets all the Files in the current folder
    /// </summary>
    public ObservableCollection<FileSystem> SubDirectories
    {
        get
        {
            return subDirectoriesField;
        }
        set
        {
            if (subDirectoriesField != value)
            {
                subDirectoriesField = value;
                RaisePropertyChanged("SubDirectories");
            }
        }
    }
    /// <summary>
    /// Gets or sets name of the file system 
    /// </summary>
    public string Name
    {
        get;
        set;
    }
    /// <summary>
    /// Gets or sets full path of the file system
    /// </summary>
    public string FullPath
    {
        get;
        set;
    }
    /// <summary>
    /// object of parent, null if the current node is root
    /// </summary>
    public FileSystem Parent
    {
        get;
        set;
    }
    public FileSystem(string fullPath, FileSystem parent)
    {
        Name = fullPath != null ? fullPath.Split(new char[] { System.IO.Path.DirectorySeparatorChar },
            StringSplitOptions.RemoveEmptyEntries).Last()
        FullPath = fullPath;
        Parent = parent;
        AddSubDirectories(fullPath);
    }
    public IEnumerator GetEnumerator()
    {
        return SubDirectories.GetEnumerator();
    }
    private void AddSubDirectories(string fullPath)
    {
        string[] subDirectories = Directory.GetDirectories(fullPath);
        SubDirectories = new ObservableCollection<FileSystem>();
        foreach (string directory in subDirectories)
        {
            SubDirectories.Add(new FileSystem(directory, this));
        }
    }
    }
