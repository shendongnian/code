    Assembly assembly;
    assembly = Assembly.Load(File.ReadAllBytes(filepath));
    Type[] listOfAllClassInDll = assembly.GetTypes();
    List<string> listOfAllClassNamesInDll = new List<string>();
    foreach (Type classInDll in listOfAllClassInDll)
    {
       listOfAllClassNamesInDll.Add(classInDll.Name);
    }
    File.Delete(filepath);
