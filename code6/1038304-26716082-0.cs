    public string ControlName
    {
        get
        {
            return Name;
        }
        set
        {
            Name = value;
            MessageBox.Show(value);
        }
    }
