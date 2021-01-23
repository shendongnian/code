    private readonly string _value;
    private readonly bool _readonly;
    private Frequency _instance;
    private Frequency(string value)
    {
        _readonly = true;
        _value = value;
        _instance = this;
        _list[value] = _instance;
    }
	public Frequency()
    {
        _readonly = false;
        _instance = Frequency.Null;
    }
	[XmlText]
    public string Value
    {
        get
        {
            if (_instance == Frequency.Null) return null;
            return _instance._value;
        }
        set
        {
            if (_readonly)
                throw new InvalidOperationException("Cannot assign a value to an enumeration.");
            if (value == null) _instance = Frequency.Null;
            else
            {
                if (!_list.ContainsKey(value))
                    throw new NullReferenceException(string.Format("Frequency.{0} not found.", value));
                _instance = _list[value];
            }
        }
    }
    public override string ToString()
    {
        return Value;
    }
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (this.GetType() != obj.GetType()) return false;
        // safe because of the GetType check
        Frequency item = (Frequency)obj;
        return System.Object.ReferenceEquals(_instance, item);
    }
    public override int GetHashCode()
    {
		if (_value == null) return "".GetHashCode();
        else return _value.GetHashCode();
    }
    public int CompareTo(object obj)
    {
        if (obj is Frequency)
        {
			if (_value == null)
			{
				if (obj == null) return 0;
				else return -1;
			}
            Frequency compare = (Frequency)obj;
            return _instance.Value.CompareTo(compare.Value);
        }
        else
            throw new ArgumentException("Object is not a Frequency.");
    }
