    Test test = new Test();
    FileStream fs = new FileStream("output", FileMode.Create);
    // Construct a BinaryFormatter and use it to serialize the data to the stream.
    BinaryFormatter formatter = new BinaryFormatter();
    try 
    {
        formatter.Serialize(fs, test); 
    }
    catch (SerializationException e) 
    {
        Console.WriteLine("Failed to serialize. Reason: " + e.Message);
        throw;
    }
    finally 
    {
        fs.Close();
    }
