    Ch8Array arr = new Ch8Array();
    using (BinaryReader reader = new BinaryReader(File.Open("test", FileMode.Open))) {
        reader.Read(arr.ch, 0, arr.ch.Length);
    } 
    using (BinaryWriter writer = new BinaryWriter(File.Open("test2", FileMode.Create))) {
        writer.Write(arr.ch);
    }   
           
