    private PropertyChangedEventHandler propertyChanged;
    public event PropertyChangedEventHandler PropertyChanged {
        add { propertyChanged += value; }
        remove { propertyChanged -= value; }
    }
