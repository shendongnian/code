    // these call the int? overload
    a.M(default(int?));
    a.M((int?)null);
    a.M(new int?());
    a.M(i: null);
    int? i = null;
    a.M(i);
    
    // these call the string overload
    a.M(default(string));
    a.M((string)null);
    a.M(s: null);
    string s = null;
    a.M(s);
