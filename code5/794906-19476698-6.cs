    class Texture<TChannels, TBPC> where TChannels : INumOfChannels,new() where TBPC : IBitsPerChannel,new()
    {
        public Type ChannelsAttribute
        {
            get { return typeof(TChannels); }
        }
    
        public Type BitsPerChannelAttribute
        {
            get { return typeof(TBPC); }
        }
    }
