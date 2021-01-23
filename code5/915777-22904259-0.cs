    int a ;
    Int32.TryParse("5",out a);
    System.Out.WriteLine("a="+a); // Will be: a=5
    Int32.TryParse("e",out a);
    System.Out.WriteLine("a="+a); // Will be: a=0
