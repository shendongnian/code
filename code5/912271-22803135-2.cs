    private string _someString = "";
    public string SomeString
    {
        get
        {
            return _someString;
        }
        set
        {
            if (String.IsNullOrEmpty(value) == false)
            {
                _someString = value;
            }
            else
            {
                _someString = "---";
            }
        }
    }
