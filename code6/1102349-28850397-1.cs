    public sealed class WindowViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<Parent> parents;
        private readonly ICommand myCommand;
        private Parent selectedParent;
        public WindowViewModel()
        {
            parents = new ObservableCollection<Parent>
            {
                new Parent{ Name = "P1"},
                new Parent{ Name = "P2"}
            };
            myCommand = new ActionCommand(DoWork);
        }
        private void DoWork()
        {
            var selectedChild = SelectedParent == null ? null : SelectedParent.SelectedChild;
        }
        public Parent SelectedParent
        {
            get { return selectedParent; }
            set
            {
                if (selectedParent == value)
                    return;
                selectedParent = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Parent> Parents
        {
            get { return parents; }
        }
        public ICommand MyCommand
        {
            get { return myCommand; }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
