    string _number = "64.345";
    double _double;
    try
    {
       _double = Double.Parse(_number)
       // Other actions
    }
    catch (FormatException ex)
    {
       // Actions for when invalid parameter is given for parse
    }
