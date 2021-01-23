    var binFormatter = new Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    using (var fs = new FileStream(@"C:\temp.dat", FileMode.OpenOrCreate, FileAccess.Read))
    {
        do
        {
            // Deserialize the credential from the file stream
            var credential = (Credential)binFormatter.Deserialize(fs);
            // Process the credential here
        // Loop until the end of the file
        } while (fs.Position < fs.Length - 1)
    }
    
