    public class ReportViewModel : NamedViewModel
    {
       ....
    }
    public class NetworkViewModel : NamedViewModel
    {
       ....
    }
    public class NamedViewModel : INotifyPropertyChanged
    {
      public string Name {get;set;}
      public bool IsChecked{get;set;}
      public ObservableCollection<NamedViewModel> Children {get; private set;}
      ...etc....
    }
