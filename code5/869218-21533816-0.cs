    var assembly = Assembly.GetExecutingAssembly();
    var formatter = new BinaryFormatter();
    using (var file = File.OpenWrite("assembly.bin"))
    {
        formatter.Serialize(file, assembly);
        file.Close();
    }
