    public class ListViewModel : INotifyPropertyChanged
    {
      // Raise OnPropertyChanged on the setter for game items.. also create backing property
      public ObservableCollection<GameItem> GameItems { get; set; }
    }
