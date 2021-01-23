    [StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 1), Serializable]
    public struct MyStruct
    {
        public byte StartOfText;
        public byte DisableChecksum;
        public byte ProtocolVersion;
        public byte Code;
        public Int16 Size;
        public byte[] Data;
        public byte EndOfText;
    
        public MyStruct(CommandCode commandCode, string commandData)
        {
            this.StartOfText = 0x02;
            this.DisableChecksum = 0x00;
            this.ProtocolVersion = 0x35;
            this.Code = (byte)commandCode;
            this.Size = (Int16)commandData.Length;
            this.Data = new byte[commandData.Length];
            this.Data = Encoding.ASCII.GetBytes(commandData);
            this.EndOfText = 0x03;
        }
    
        public byte[] ToByteArray()
        {
            BinaryFormatter formatter = null;
            MemoryStream stream = null;
            byte[] arr = null;
            try
            {
                formatter = new BinaryFormatter();
                stream = new MemoryStream();
                formatter.Serialize(stream, this);
                arr = stream.ToArray();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if(null != stream)
                {
                    stream.Dispose();
                }
            }
            return arr;
        }
    }
