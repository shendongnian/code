        public static byte[] BuildPacket(string Command, string DataBytes)
        {
            List<byte> output = new List<byte>();
            // Add command text
            output.AddRange(Encoding.ASCII.GetBytes(Command));
            // Add data bytes
            output.AddRange(Encoding.ASCII.GetBytes(DataBytes));
            // Add checksum
            byte chkSum = 0;
            foreach(byte b in output )
            {
                chkSum += b;
            }
            output.AddRange(Encoding.ASCII.GetBytes(chkSum.ToString("X")));
            output.AddRange(Encoding.ASCII.GetBytes(Environment.NewLine));
            return output.ToArray();
        }
