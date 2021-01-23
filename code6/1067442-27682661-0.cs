    class PacketRegistration {
        public void RegisterPacketType(Type packetType) {...}
        public void RegisterPacketType<TPacket>() where TPacket:Packet { 
             RegisterPacket(typeof(TPacket)); 
        }
        public void RegisterPacketTypesFromAssembly(Assembly assembly) {...}
        public void RegisterPacketTypesFromCurrentAssembly() {
            RegisterPacketTypesFromAssembly(Assembly.GetCallingAssembly());
        }
