    [Export]
    public sealed class ShellViewModel : NotificationObject
    {
        public ShellViewModel()
        {
             Players = new ObservableCollection<IPlayerViewModel>();
    
             // Get the list of player models
             // from the database (ICollection<IPlayer>)
             var players = GetCollectionOfPlayerModels();
    
             foreach (var player in players)
             {
                 var vm = PlayerViewModelFactory.Create(player);
    
                 Players.Add(vm);
             }
        }
    
        [Import]
        private IPlayerViewModelFactory PlayerViewModelFactory { get; set; }
    
        public ObservableCollection<IPlayerViewModel> Players { get; private set; }
    }
