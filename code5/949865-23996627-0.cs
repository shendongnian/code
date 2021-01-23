    SO this is how I ended up implementing it Thanks to John and mclaassen. 
    
    
    In my AssemblyInfo.cs, the made the following changesg:
    
    before:
    [assembly: AssemblyVersion("1.0.0.0")]
    [assembly: AssemblyFileVersion("1.0.0.0")]
    
    after:
    [assembly: AssemblyVersion("1.0.*")]
    [assembly: AssemblyFileVersion("1.0.*")]
    
    then I wrote a helper class which can access the AssembleyVersion number, with a get method.
    
       public string GetVersion() 
            {
                string version ;
                version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                return version;
            }
    
    so when ever I call this method it gives me a string which is nothing but my version number.
