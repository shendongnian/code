    string[] assemblyPaths = System.IO.Directory.GetFiles(@"C:\Windows\Microsoft.NET\", "*.dll", System.IO.SearchOption.AllDirectories);
    foreach (string assemblyPath in assemblyPaths)
    {
       Assembly assembly = null;
       assembly = Assembly.LoadFrom(assemblyPath);
    
       // Go through all the types in it
       foreach (Type t in assembly.GetExportedTypes())
       {
           // Publically creatable exception?
           if (t.IsPublic && t.Name == "File" && t.Namespace == "System.IO")
           {
               // The type "t" is the type you are looking for
           }
       }
    }
