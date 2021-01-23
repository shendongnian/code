    public static class Package
    {
       // Method for basic checksum
       private static byte GetBasicChecksum(this byte[] data)
       {
          byte sum = 0;
          unchecked // Let overflow occur without exceptions
          {
             foreach (byte b in data)
             {
                sum += b;
             }
          }
          return sum;
       }
    
       // Serialize to bytes (BinaryFormatter)
       public static byte[] SerializeToBytes<T>(this T source)
       {
          using (var stream = new MemoryStream())
          {
             var formatter = new BinaryFormatter();
             formatter.Serialize(stream, source);
             return stream.ToArray();
          }
       }
    
       // Deerialize from bytes (BinaryFormatter)
       public static T DeserializeFromBytes<T>(this byte[] source)
       {
          using (var stream = new MemoryStream(source))
          {
             var formatter = new BinaryFormatter();
             stream.Seek(0, SeekOrigin.Begin);
             return (T)formatter.Deserialize(stream);
          }
       }
    
       // Check if we have enough data
       // will throw if it detects a corruption (basic)
       // return false if there isnt enough data to determine
       // return true and length of the package if sucessfull
       public static bool HasValidPackage(this Stream stream, out Int32 messageSize)
       {
          messageSize = -1;
    
          if (stream.Length - stream.Position < sizeof(byte) * 2 + sizeof(Int32))
             return false;
    
    
          var stx = stream.ReadByte();
    
          if (stx != 2)
             throw new InvalidDataException("Invalid Package : STX Failed");
    
          var packageLength = new byte[sizeof(Int32)];
          stream.Read(packageLength, 0, sizeof(Int32));
          messageSize = BitConverter.ToInt32(packageLength, 0) - sizeof(byte) * 3;
          var checkSum = stream.ReadByte();
    
          if (checkSum != packageLength.GetBasicChecksum())
             throw new InvalidDataException("Invalid Package : CheckSum Failed");
    
          return stream.Length >= messageSize;
    
       }
       // Pack the message
       public static byte[] PackMessage<T>(this T source, MessageType messageType)
       {
          var buffer = source.SerializeToBytes();
          var packageLength = BitConverter.GetBytes(buffer.Length + sizeof(byte) * 3);
          using (var stream = new MemoryStream())
          {
             stream.WriteByte(2);
             stream.Write(packageLength, 0, sizeof(Int32));
             stream.WriteByte(packageLength.GetBasicChecksum());
             stream.WriteByte((byte)messageType);
             stream.Write(buffer, 0, buffer.Length);
             stream.WriteByte(3);
             return stream.ToArray();
          }
       }
    
       // Unpack the message
       public static MessageType UnPackMessage(this Stream stream, Int32 messageSize, out byte[] buffer)
       {
    
          var messageType = (MessageType)stream.ReadByte();
          buffer = new byte[messageSize];
          stream.Read(buffer, 0, buffer.Length);
    
          var etx = stream.ReadByte();
    
          if (etx != 3)
             throw new InvalidDataException("Invalid Package : ETX Failed");
    
          return messageType;
       }
    
    }
