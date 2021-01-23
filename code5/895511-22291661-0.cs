    public enum PacketTypes
    {
        INVALID = -1;
        LOGIN = 0;
    }
    public class Packet
    {
        public PacketTypes PacketType { get; set;}
    }
