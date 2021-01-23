            ...
            try
                {
                    memoryStream = new MemoryStream();
                    writer = new BinaryWriter(memoryStream);
                    writer.Write((byte)2);  // The command (version 2)
                    
                    // 4 bytes for the frameLength (this includes all the items ids listed below)
                    int frameLength = 1 + 2 + 32 + 1 + 2 + payload.Length; // (tokenCommand + tokenLength + token) + (payloadCommand + payloadLength + payload) 
                    this.writeIntBytesAsBigEndian(writer, frameLength, 4);
                    // DEVICE ID
                    writer.Write((byte)1);  // Command for Item ID: deviceId
                    byte[] tokenBytes = this.HexStringToByteArray(token);
                    this.writeIntBytesAsBigEndian(writer, tokenBytes.Length, 2);
                    writer.Write(tokenBytes);
                    // PAYLOAD
                    writer.Write((byte)2); // Command for Item ID: payload
                    this.writeIntBytesAsBigEndian(writer, payload.Length, 2);
                    writer.Write(Encoding.ASCII.GetBytes(payload), 0, payload.Length);
                    writer.Flush();
                    sslStream.Write(memoryStream.ToArray());
                    sslStream.Flush();
                    responseString += " SENT TO: " + token + "<br />";
                }
                ...
        private void writeIntBytesAsBigEndian(BinaryWriter writer, int value, int bytesCount)
        {
            byte[] bytes = null;
            if (bytesCount == 2)
                bytes = BitConverter.GetBytes((Int16)value);
            else if (bytesCount == 4)
                bytes = BitConverter.GetBytes((Int32)value);
            else if (bytesCount == 8)
                bytes = BitConverter.GetBytes((Int64)value);
            if (bytes != null)
            {
                Array.Reverse(bytes);
                writer.Write(bytes, 0, bytesCount);
            }
        }
