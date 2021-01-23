    [StructLayout(LayoutKind.Explicit, Size = 11, Pack = 0)]
    public struct MyStructure
    {
        public string StringFromBytes
        {
            get
            {
                if (ByteArrayField == null || ByteArrayField.Length == 0)
                {
                    return string.Empty;
                }
                return Utilitites.BytesToString(ByteArrayField);
            }
        }
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] [FieldOffset(0)] public byte[] ByteArrayField;
        [MarshalAs(UnmanagedType.U2)] [FieldOffset(8)] public ushort WordField;
        [MarshalAs(UnmanagedType.I1)] [FieldOffset(10)] public sbyte dBm0;
    }
