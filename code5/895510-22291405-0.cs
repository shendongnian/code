    public static class PacketTypesExtensions {
        static readonly IDictionary<PacketTypes,int> IdForType = new Dictionary<PacketTypes,int> {
            { PacketTypes.INVALID, -1 }
        ,   { PacketTypes.LOGIN,    0 }
        };
        static readonly IDictionary<PacketTypes,string> DescrForType = new Dictionary<PacketTypes,string> {
            { PacketTypes.INVALID, "<invalid packet type>" }
        ,   { PacketTypes.LOGIN,   "<user login>" }
        };
        public static string Description(this PacketTypes t) {
            return DescrForType[t];
        }
        public static int Id(this PacketTypes t) {
            return IdForType[t];
        }
    }
