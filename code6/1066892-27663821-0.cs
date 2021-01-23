    public class ByteArrayInClass
    {
       public byte Option { get; set; }
       public ushort Elements { get; set; }
       public byte[] Bytes { get; set; }
    
       public ByteArrayInClass(byte option, ushort nElements)
       {
          this.Option = option;
          this.Elements = nElements;
          this.Bytes = new byte[nElements];
          for (var i = 0; i < nElements; i++)
          {
             this.Bytes[i] = (byte)i;
          }
       }
       public ByteArrayInClass(byte[] array)
       {
          this.Elements = (ushort)array.Length;
          this.Bytes = new byte[this.Elements];
          array.CopyTo(this.Bytes, 0);
       }
       public static byte[] ObjectToBytes(ByteArrayInClass value)
       {
          var result = new byte[value.Elements];
          value.Bytes.CopyTo(result, 0);
          return result;
       }
    
       public static ByteArrayInClass BytesToObject(byte[] bytes)
       {
          return new ByteArrayInClass(bytes);
       }
    }
