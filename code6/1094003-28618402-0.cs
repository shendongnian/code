    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class Header {
        //....
    }
    public class Packet {
        public Header Header;
        public byte[] VariableLengthData;
    }
