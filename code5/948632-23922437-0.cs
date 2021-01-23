    private string _name = string.Empty;
    public new string Name
    {
        get { return base.Name; }
        set
        {
            _name = base.Name = value;
            CreateLabelText(_name);
        }
    }
    CreateLabelText(string ValueIn)
    {
        ...more code here...
    }
