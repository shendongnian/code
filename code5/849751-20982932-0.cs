    using System.Runtime.InteropServices;
    [StructLayout(LayoutKind.Explicit)]
    struct Union
    {
      [FieldOffset(0)]
      public sbyte Signed;
      
      [FieldOffset(0)]
      public byte Unsigned;
    }
