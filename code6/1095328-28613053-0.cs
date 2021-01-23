        // Constructor for received packet
        public GameDataPacket(byte[] data)
        {
            int packetOffset = 0;
            this.command_ = (MultiplayerService.Command)BitConverter.ToInt32(data, packetOffset);
            packetOffset += 4;
            // read the length (in bytes) of the nickname
            int nickDataLength = BitConverter.ToInt32(data, packetOffset);
            packetOffset += 4;
            
            // read the nick name
            this.nickname_ = Encoding.UTF8.GetString(data, packetOffset, nickDataLength);
            packetOffset += nickDataLength;
            this.x_ = BitConverter.ToSingle(data,  packetOffset);
            packetOffset += 4;
            this.y_ = BitConverter.ToSingle(data,  packetOffset);
        }
        public byte[] ToByte()
        {
            // FORMAT
            // |Command|NameDataLength|Name|x|y|
            List<byte> result = new List<byte>();
            result.AddRange(BitConverter.GetBytes((int)command_));
            byte[] nicknameBytes = Encoding.UTF8.GetBytes(nickname_);
            result.AddRange(BitConverter.GetBytes(nicknameBytes.Length));
            result.AddRange(nicknameBytes);
            result.AddRange(BitConverter.GetBytes(x_));
            result.AddRange(BitConverter.GetBytes(y_));
            return result.ToArray();
        }
