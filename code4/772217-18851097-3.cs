    using System.Runtime.Serialization.Formatters.Binary;
    ...    
    // writing
    FileStream fs = File.Open("...");
    BinaryFormatter bf = new BinaryFormatter();
    bf.Serialize(fs, theArray);
    // reading
    string[,,] theArray;
    FileStream fs = File.Open("...");
    BinaryFormatter bf = new BinaryFormatter();
    theArray = (string[,,])bf.Deserialize(fs);
