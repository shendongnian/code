    public class Node : INotifyPropertyChanged
    {
        private Node _parent;
        public Node Parent 
        {
            get
            {
                return this._parent;
            }
    
            set
            {
                if (value != this._parent)
                {
                    this._parent= value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public ObservableCollection<Node> Children { get; } = new ObservableCollection<Node>()
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?(this, new PropertyChangedEventArgs(propertyName));
        }
    
    }
