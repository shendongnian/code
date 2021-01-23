    public sealed class ViewModelLol : INotifyPropertyChanged
    {
        // init from ctor
        public ObservableCollection<ServerInfo> Servers {get;private set;}
        public ServerInfo SelectedServer {get;set;} // should be INPC impl, but yawn
        // boring stuff goes here
    }
