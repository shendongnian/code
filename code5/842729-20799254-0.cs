    public string Duration 
    {
        get { return _duration ; }
        set
        {
            _name = value;
            if (String.IsNullOrEmpty(value) || Int32.TryParse(value))
            {
                throw new ArgumentException("Dauer has to be a number..");
            }
        }
    }
