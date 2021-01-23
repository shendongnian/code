    // The 5+5+2 is the assumed lenght of a line
    const int recLength = 12;
    
    string path = @"d:\temp\DATA1.txt";
   
    if (File.Exists(path))
    {
        int recNum = 4;
        
        string key;
        string value;
        using(BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            // The key point is the Position property that should be set using
            // some kind of simple math to the exact position needed
            br.BaseStream.Position = recNum * recLength;
            // Read the 5 bytes and build the key and value string, 
            // note that reading (or writing) advances the Position 
            key = new string(br.ReadChars(5));
            value = new string(br.ReadChars(5));
        }
        Console.WriteLine(key)        ;
        Console.WriteLine(value)        ;
        
        key = "00009";
        value = "KKKKK";
        
        using(BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Open)))
        {
            // Again the math required to position for the write
            bw.BaseStream.Position = recNum * recLength;
            bw.Write(key.ToCharArray());
            bw.Write(value.ToCharArray());
        }
        
    }
