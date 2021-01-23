    using System.Runtime.InteropServices;
    [StructLayout(LayoutKind.Explicit)]
    struct ByteArray {
      [FieldOffset(0)]
      public byte Byte1;
      [FieldOffset(1)]
      public byte Byte2;
      [FieldOffset(2)]
      public byte Byte3;
      [FieldOffset(3)]
      public byte Byte4;
      [FieldOffset(4)]
      public byte Byte5;
      [FieldOffset(5)]
      public byte Byte6;
      [FieldOffset(6)]
      public byte Byte7;
      [FieldOffset(7)]
      public byte Byte8;
      [FieldOffset(0)]
      public int Int1;
      [FieldOffset(4)]
      public int Int2;
    }
