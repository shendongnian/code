    private TreeModel _parent;
    public TreeModel Parent
    {
        get { return _parent; }
        set
        {
            _parent = value;
            NotifyPropertyChange(() => Parent);
        }
    }
