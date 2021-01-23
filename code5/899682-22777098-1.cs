    public static void HandlePacket(string MsgRec, Client Client)
        {
            string[] Info = MsgRec.Split('|');
            string Type = Info[0];
            if (Type == "")
            {
                return;
            }
            string subtype = Info[1];
            int TLen = Type.Length + subtype.Length + 2;
            string Data = MsgRec.Remove(0, TLen);//this is the main data the server sent
            ushort PacketType = ushort.Parse(Type);
            ushort SubType = ushort.Parse(subtype);
            switch ((Structs.PacketType)PacketType)
            {
                case Structs.PacketType.Login:
                    {
                     //do your stuff here
                     break
                    }
                case Structs.PacketType.Image:
                    {
                     //convert the Data back to byte array then get the image out from it
                     break
                    }
                case Structs.PacketType.ByteArray:
                    {
                     //convert the Data back to byte array
                     break
                    }
            }
        }
