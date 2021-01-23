    Assembly assem = Assembly.LoadFrom(YourFilePath);
    Console.WriteLine("Assembly Full Name:");
    Console.WriteLine(assem.FullName);
    AssemblyName assemName = assem.GetName();
    Console.WriteLine("Version: {0}.{1}", assemName.Version.Major, assemName.Version.Minor);
