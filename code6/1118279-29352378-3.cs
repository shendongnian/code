    public class Message
    {
        public MessageType MessageType { get; set; }
    
        public byte[] Body { get; set; }
    
        public byte[] Serialize()
        {
            //Data will be serialized in the format 
            //  - MessageType (1 byte)
            //  - BodyLength (4 bytes)
            //  - Body (x Bytes)
    
            //We allocate a fixed buffer as we know the size already.
            var buffer = new byte[Body.Length + 5];
    
            using(var ms = new MemoryStream(buffer)
            {
                Serialize(ms);
            }
    
            //Return our buffer.
            return buffer 
        }
        //Just in case you have a stream instead of a byte[]
        public void Serialize(Stream stream)
        {
            using(var writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write((byte)this.MessageType);
                writer.Write(Body.Length);
                writer.Write(Body);
            }
        }
    
        public static Message Deserialize(byte[] data)
        {
            using(var ms = new MemoryStream(data))
            {
                return Message.Deserialize(ms);
            }
        }
    
        //Just in case you have a stream instead of a byte[]
        public static Message Deserialize(Stream data)
        {
            var message = new Message();
            
            //Use the default text encoding (does not matter for us) and leave the stream open.
            using(var reader = new BinaryReader(data, Encoding.UTF8, true))
            {
                //We do the same order of operations.
                message.MessageType = (MessageType)reader.ReadByte();
                var bodyLength = reader.ReadInt32();
                message.Body = reader.ReadBytes(bodyLength);
            }
    
            return message;
        }
    }
