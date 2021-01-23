    List<Base> values = GetValues();
    
    foreach (Base value in values)
    {
        switch (value.DataType)
        {
            case DataType.MyString:
                MyString myString = value as MyString;
                ...
                
            case DataType.MyInt:
                MyInt myInt = value as MyInt;
                ...
        }
    }
