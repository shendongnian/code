    public abstract class PacketHandlerBase : Engine
    {
        public abstract bool SendInfoPacket(int someInt, string someInput);
        public abstract List<InfoPacket> BuildInfoPacket(string someInput);
    
        public abstract bool SendUsagePacket(int someInt, string someInput);
        public abstract List<UsagePacker> BuildUsagePacket(string someInput);
        //...
    }
    public class InfoPacket1014 : InfoPacket
    { 
        ///...
    }
    public class PacketHandler1011 : PackerHandlerBase
    {
        //...
        public override List<InfoPacket> BuildInfoPacket(string someInput);
        {
            // code implementation
            return new List<InfoPacket> { new InfoPacket1011(), ... };
        }
    }
