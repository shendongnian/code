    public class NodeViewModel : PropertyChangedBase
    {
        private bool isSelected;
        public NodeViewModel(string displayName)
        {
            this.DisplayName = displayName;
            this.Children = new ObservableCollection<NodeViewModel>();
        }
        public ObservableCollection<NodeViewModel> Children { get; private set; }
        public string DisplayName { get; private set; }
        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                if (value.Equals(this.isSelected))
                {
                    return;
                }
                this.isSelected = value;
                this.NotifyOfPropertyChange(() => this.IsSelected);
                Console.WriteLine(value);
            }
        }
    }
