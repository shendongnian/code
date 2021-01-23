    ICollection selecteditems = iselect.Snapshot();
    
    //Content c; //The variable is here in C# 4 and older
    foreach (object temp in selecteditems)
    {
        Content c; //The variable is here in C# 5 and newer;
        c = (Content)temp;
        ...
    }
