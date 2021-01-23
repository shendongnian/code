    public abstract class NetworkMessage
    {
        private List<byte> _buffer;
        protected abstract void InternalDeserialize(BinaryReader reader);
        protected NetworkMessage()
        {
            _buffer = new List<byte>();
        }
        public void Deserialize()
        {
            using (MemoryStream stream = new MemoryStream(_buffer.ToArray()))
            {
                BinaryReader reader = new BinaryReader(stream);
                this.InternalDeserialize(reader);
            }
        }
    }
    public class YourMessage : NetworkMessage
    {
        public int YourField
        {
            get;
            set;
        }
        protected override void InternalDeserialize(BinaryReader reader)
        {
            YourField = reader.ReadInt32();
        }
    }
