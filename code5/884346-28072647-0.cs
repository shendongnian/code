    Assembly assembly = Assembly.GetAssembly(typeof(SomeClassInBProject));
    using (FileStream fs = assembly.GetFile("myfile"))
    {
        // Manipulate the FileStream here
    }
