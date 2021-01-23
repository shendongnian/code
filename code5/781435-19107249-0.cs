    string one = "first memorystream";
    string two = ", and the second";
    
    MemoryStream ms = new MemoryStream();
    MemoryStream ms2 = new MemoryStream();
    
    byte[] oneb = Encoding.UTF8.GetBytes(one);
    byte[] twob = Encoding.UTF8.GetBytes(two);
    
    ms.Write(oneb, 0, oneb.Length);
    ms2.Write(twob, 0, twob.Length);
    
    ms.Length.Dump("Stream 1, Length");
    ms2.Length.Dump("Stream 2, Length");
    
    ms2.Position = 0; // <-- You have to set the position back to 0 in order to write it, otherwise the stream just continuous where it left off, the end
    ms2.CopyTo(ms, ms2.GetBuffer().Length); // <-- simple "merge"
    
    /*
     * Don't need the below item anymore
     */ 
    //ms.Write(ms2.GetBuffer(), (int)ms.Length, (int)ms2.Length);
    ms.Length.Dump("Combined Length");
    
    ms.Position = 0;
    
    StreamReader rdr = new StreamReader(ms, Encoding.UTF8);
    rdr.ReadToEnd().Dump();
