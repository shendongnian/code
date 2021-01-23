    public void myFunction (params object[] args)
    {
        int myInt = args.OfType<int>().FirstOrDefault();
        ...
    }
     myFunction(2.4, false, 3);
  
