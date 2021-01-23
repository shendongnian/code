     string exeFilePath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
     string exeDirPath = System.IO.Path.GetDirectoryName(exeFilePath);
     string targetFile = "subFolder\\ResourceDictionary.xaml";
     string dictionaryPath = new Uri(System.IO.Path.Combine(exeDirPath, targetFile)).LocalPath;
     string xamlString = File.ReadAllText(dictionaryPath);
     ResourceDictionary resourceDictionary = (ResourceDictionary)XamlReader.Parse(xamlString);
