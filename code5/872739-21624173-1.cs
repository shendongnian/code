    private string _someField;
    private string SomeProperty
    {
        get
        {
            if (_someField== null)
            {
                _someField= LoadData();
            }
    
            return _someField;
        }
    }
