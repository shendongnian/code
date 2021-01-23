    public interface IFolder
    {
        string FullPath { get; }
        string FolderLabel { get; }
        ObservableCollection<IFolder> Folders { get; } 
    }
