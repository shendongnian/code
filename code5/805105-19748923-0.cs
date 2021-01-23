    public int some_int
    {
        get { return _someInt; }
        set
        {
            _someInt = value;
            var v = check_sender();
            Console.Out.WriteLine("in the setter of {0}", v);
        }
    }
    private int _someInt;
    private string check_sender([CallerMemberName]string property = "")
    {
        return property;
    }
