    private ICollection<string> _variable;
    public ICollection<string> VariableName
    {
        get
        {
            if (_variable == null)
            {
                return new Collection<string> {""};
            }
            else
            {
                return _variable;
            }
        }
        set { _variable = value; }
    }
