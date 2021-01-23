    string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
    string folder = Path.Combine(folder, "myappNameDataFolder");
    Directory.CreateDirectory(folder);
    string dataFile = Path.Combine(folder, "myappNameDataFile");
    using(Stream stateStream = File.Create(dataFile))
    {
        BinaryFormatter serializer = new BinaryFormatter();
        serializer.Serialize(stateStream, stateVariables);
    }
