    foreach(var e in values)
    {
        if(e is Enum)
        {
            Enum eAsEnum = (Enum)e;
            String mylist = Common.MyExtensions.getEnumDescription(eAsEnum);
        }
    }
