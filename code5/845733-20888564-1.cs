    int default_optionalint = 0;
    public void ExampleMethod(int required, int? optionalint,
                                string optionalstr = "default string")
    {
        int _optionalint = optionalint ?? default_optionalint;
    }
