    // the bytes
    var bytes = new byte[] {3, 204};
    // are the bytes little endian?
    var littleEndian = false;  // no
    
    // What architecure is the BitConverter running on?
    if (BitConverter.IsLittleEndian != littleEndian) 
    {
       // reverse the bytes if endianess mismatch
       bytes = bytes.Reverse().ToArray();
    }
    // convert
    var value =  BitConverter.ToInt16( bytes , 0);
    value.Dump(); // or Console.WriteLine(value); --> 972
