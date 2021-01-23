    public static Packet ExtAddPlayerName(short nameid, string name, string ListName, string group, byte perm)
            {
                Packet packet = new Packet(OpCode.ExtAddPlayerName);
                ToNetOrder(nameid, packet.Bytes, 1);
                Encoding.ASCII.GetBytes(name.PadRight(64), 0, 64, packet.Bytes, 3);
                Encoding.ASCII.GetBytes(ListName.PadRight(64), 0, 64, packet.Bytes, 67);
                Encoding.ASCII.GetBytes(group.PadRight(64), 0, 64, packet.Bytes, 131);
                packet.Bytes[132] = perm;
                return packet;
            }
    
    internal static void ToNetOrder( short number, byte[] arr, int offset ) {
                arr[offset] = (byte)( ( number & 0xff00 ) >> 8 );
                arr[offset + 1] = (byte)( number & 0x00ff );
            }
