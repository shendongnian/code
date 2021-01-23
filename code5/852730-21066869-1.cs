    class SystemInfo
    {
        private string machineName;
        private int freeSpace;
    
        public SystemInfo()
        {
            machineName = Environment.MachineName;
            freeSpace = GetTotalFreeSpace("C:\\");
        }
    
        public byte[] Encode()
        {
            var machineNameAsByteArray = System.Text.Encoding.ASCII.GetBytes(machineName);
            var messageLength = machineNameAsByteArray.Length + sizeof(int);
            var messagePlusHeaderLength = messageLength + sizeof(int);  // 4-byte length field
            var bytes = new byte[messagePlusHeaderLength];
    
            var offset = 0;
            System.Buffer.BlockCopy(BitConverter.GetBytes(messagePlusHeaderLength), 0, bytes, offset, sizeof(int));
            offset += sizeof(int);
            System.Buffer.BlockCopy(machineNameAsByteArray, 0, bytes, offset, machineNameAsByteArray.Length);
            offset += machineNameAsByteArray.Length;
            System.Buffer.BlockCopy(BitConverter.GetBytes(freeSpace), 0, bytes, offset, sizeof(int));
    
            return bytes;
        }
    }
