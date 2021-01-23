    string pySrc;
    var resourceName = "ConsoleApplication1.SomeCode.py";
    using (var stream = System.Reflection.Assembly.GetExecutingAssembly()
                              .GetManifestResourceStream(resourceName))
    using (var reader = new System.IO.StreamReader(stream))
    {
        pySrc = reader.ReadToEnd();
    }
    var x = py.CreateScriptSourceFromString(pySrc);
