    Assembly asm = Assembly.GetAssembly(typeof(<<assemblyNamespace>>.<<name_of_page_class>>));
    string asmPath = asm.CodeBase;
    
    string app_DataFolder = Path.GetFullPath(Path.GetDirectoryName(asmPath.Remove(0, "file:\\\\\\".Length)) + "\\..\\App_Data");
    
    string filePath = Path.Combine(app_DataFolder, "Sample.xml");
