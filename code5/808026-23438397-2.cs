    internal class ARAutomatchServiceClient : ClientBase<IARAutomatchService>
    {
        internal static HashSet<ChannelFactory> cachedChannelFactories = new HashSet<ChannelFactory>();
        static ARAutomatchServiceClient()
        {
            ClientBase<IARAutomatchService>.CacheSetting =
                    System.ServiceModel.CacheSetting.AlwaysOn;
        }
        public ARAutomatchServiceClient()
        {
            cachedChannelFactories.Add(this.ChannelFactory);
        }
        //... service methods here
    }
