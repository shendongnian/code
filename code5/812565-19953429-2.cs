    public class Child
    {
        public string Name { get; set; }
        private Parent _parent;
        public Parent Parent
        {
            get
            {
                return _parent;
            }
            set 
            {
                if (_parent == value)
                    return;
                if (_parent != null && _parent.Children.Contains(this))
                    _parent.Children.Remove(this);
                _parent = value;
                if (_parent != null && !_parent.Children.Contains(this))
                    _parent.Children.Add(this);
            }
        }
    }
