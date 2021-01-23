    public string Name {
        get { return name; }
        set {
            name = value;
            var eh = NameChanged;   // avoid race condition.
            if (eh != null)
                eh(this, EventArgs.Empty);
        }
    }
    private string name;
    public event EventHandler NameChanged;
