    interface IViewModel : INotifyPropertyChanged,IDisposable
    {
    }
    interface IColumnViewModel : IViewModel
    {
    }
    class ViewModelBase : IViewModel
    {
        // ... MVVM basics, PropertyChanged etc. ...
    }
    class MainViewModel : ViewModelBase
    {
        ObservableCollection<IColumnViewModel> Columns {get; set}
    }
