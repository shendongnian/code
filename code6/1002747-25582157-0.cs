    public abstract class Channel
    {
        public int ChannelId { get; private set; }
        public int GatewayId { get; set; }
        public virtual GatewayModbus Gateway { get; set; }
    }
