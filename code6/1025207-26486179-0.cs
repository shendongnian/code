    ReadEventStruct dwRead = new ReadEventStruct(); 
    Array buffer = new byte[BUFFER_SIZE];
    
    this.dw.ReadEvent(pt.Plant, pt.Index, pt.Time, pt.Interval, ref buffer, ref errMsg);
    
    byte[] byteBuffer = (byte[])buffer;                         // Convert to byte[] so BitConverter class can be used
    
    dwRead.TimeTag = BitConverter.ToDouble(byteBuffer, 0);      // First 8 bytes are TimeTag (double)
    dwRead.Quality = BitConverter.ToInt32(byteBuffer, 8);       // Next 4 bytes are Quality (integer)
    dwRead.Value   = BitConverter.ToSingle(byteBuffer, 12);     // Last 4 bytes are Value (float)
