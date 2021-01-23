    public partial class DSMain
    {
        partial void OnCreated()
        {
            if (Application.Current.IsRunningOutOfBrowser)
            {
                ClientHttpAuthenticationUtility.ShareCookieContainer(this);
            }
            System.ServiceModel.DomainServices.Client.WebDomainClient<Main.Services.IDSContract> dctx = this.DomainClient as System.ServiceModel.DomainServices.Client.WebDomainClient<Main.Services.IDSContract>;
            ChannelFactory factory = dctx.ChannelFactory;
            System.ServiceModel.Channels.CustomBinding binding = factory.Endpoint.Binding as System.ServiceModel.Channels.CustomBinding;
            binding.SendTimeout = new TimeSpan(0, 30, 0);
            binding.ReceiveTimeout = new TimeSpan(0, 30, 0);
            binding.OpenTimeout = new TimeSpan(0, 30, 0);
            binding.CloseTimeout = new TimeSpan(0, 30, 0);
        }
    }
