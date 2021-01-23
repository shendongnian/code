    [StructLayout(LayoutKind.Explicit)]
    public class Message
    {
        [FieldOffset(0)] public byte MessageId;
        [FieldOffset(1)] public byte Length;
        [FieldOffset(2)] public byte[] Data;
    }
