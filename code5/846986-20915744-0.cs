    Dictionary<String,TFoo> dict = ... // where TFoo : new() && implements a arbitrary Serialize(BinaryWriter) and Deserialize(BinaryReader) methods
    
    using(FileStream fs = File.OpenWrite("filename.dat"))
    using(BinaryWriter wtr = new BinaryWriter(fs, Encoding.UTF8)) {
        
        wtr.Write( dict.Count );
        
        foreach(String key in dict.Keys) {
            
            wtr.Write( key );
            wtr.Write('\0');
            dict[key].Serialize( wtr );
            wtr.Write('\0'); // assuming NULL characters can work as record delimiters for safety.
        }
    }
