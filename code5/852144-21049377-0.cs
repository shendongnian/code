    public abstract class PacketHandlerBase : Engine
    {
        public abstract bool SendInfoPacket(int someInt, string someInput);
        public abstract IEnumerable<PacketHeader> BuildInfoPacket(string someInput);
    
        public abstract bool SendUsagePacket(int someInt, string someInput);
        public abstract IEnumerable<PacketHeader> BuildUsagePacket(string someInput);
        //...
        //...
        //...
    }
    public class PacketHandler1011 : PackerHandlerBase
    {
        //...
        public override bool SendInfoPacket(int someInt, string someInput);
        {
            // code implementation
            // return true or false
        }
    
        public override IEnumerable<PacketHeader> BuildInfoPacket(string someInput);
        {
            yield return new InfoPacket1011(..)
            // code implementation
            // return List<InfoPacket1011>
        }
    }
