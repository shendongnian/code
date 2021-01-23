    public void loadDLLs()
    {
        Directory.CreateDirectory(System.Environment.CurrentDirectory + "\\modules");
        string[] filePaths = Directory.GetFiles(@""+System.Environment.CurrentDirectory+"\\modules", "*.dll");
       foreach (string STR in filePaths)
       {
            String nameOfDll = Path.GetFileName(STR).Split('.')[0];
            Assembly MyDALL = Assembly.LoadFile(STR);
            Type MyLoadClass = MyDALL.GetType(nameOfDll + "." + nameOfDll);
            Command obj = (Command)Activator.CreateInstance(MyLoadClass);
            commands.Add(obj);
       }
    }
