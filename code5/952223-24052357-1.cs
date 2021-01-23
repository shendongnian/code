    var codeBaseUrl = new Uri(Assembly.GetExecutingAssembly().CodeBase);
    var codeBasePath = Uri.UnescapeDataString(codeBaseUrl.AbsolutePath);
    var dirPath = Path.GetDirectoryName(codeBasePath);
    var dllPaths = Directory.GetFiles(dirpath, "*.dll");
       
    foreach(string dllPath in dllPaths)
    {
         try
         {
             kernel.Load(dllPath);
         }
         catch (Exception e)
         {
             this.Serilog()
                 .Error(e, "Failed to load assembly {assembly}", assembly);
         }
    }
