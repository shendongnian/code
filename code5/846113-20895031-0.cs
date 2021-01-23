    void Initialize()
    {
       var path = Path.Combine(Environment.CurrentDirectory, "Legacy.dll");
       if(!File.Exists(path))
       {
         // Alert the user that the accompanying DLL is missing...
       }
    }
