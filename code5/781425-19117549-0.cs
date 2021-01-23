    Stream stream = File.Open(filename, FileMode.Create);
    MyDotFormatter dotFormatter = new MyDotFormatter();
    Console.WriteLine("Writing Object Information");
    try
    {
    dotFormatter.Serialize(stream, objectToSerialize);
    }
    catch (SerializationException ex)
    {
    Console.WriteLine("Exception for Serialization data : " + ex.Message);
    throw;
    }
    finally
    {
    stream.Close();
    Console.WriteLine("successfully wrote object information");
    }
