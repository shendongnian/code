    public class MessageType
    {
        private readonly byte value;
        private MessageType(byte value)
        {
            this.value = value;
        }
        public static readonly MessageType Get = new MessageType(0);
        public static readonly MessageType Set = new MessageType(1);
        public static readonly MessageType Identify = new MessageType(2);
        public static bool operator ==(MessageType m, byte b)
        {
            if (object.ReferenceEquals(m, null))
                return false;
            if (m.value == 2 && b >= 2 && b <= 0xff)//I think <= check is redundant
                return true;
            return m.value == b;
        }
        public static bool operator !=(MessageType m, byte b)
        {
            return !(m == b);
        }
       //Need to implement Equals, GetHashCode etc
    }
