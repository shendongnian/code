    // Writing
    Int32[] bits = myDecimal.GetBits();
    
    binaryWriter.Write( (byte)bits.Length );
    foreach(Int32 component in bits) binaryWriter.Write( component );
    // Reading
    byte count = binaryReader.ReadByte();
    Int32[] bits = new Int32[ count ];
    for(Int32 i = 0; i < bits.Count; i++ ) {
        bits[i] = binaryReader.ReadInt32();
    }
    
    Decimal value = new Decimal( bits );
