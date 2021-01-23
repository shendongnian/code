    public sealed class DirectoryModel : INotifyPropertyChanged
    {
      public ObservableCollection<DirectoryModel> Subdirectories { get; set; }
      
      // Notify when this property changes for proper binding behavior!
      public bool IsTagged { get; set; }
    }
