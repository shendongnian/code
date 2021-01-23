    public static void RegisterWcfServices()
      {
            Container.Register(
                Types.FromAssemblyContaining<ITransactionService>()
                    .InSameNamespaceAs<ITransactionService>()
                    .Configure(
                        x =>
                        x.Named(x.Implementation.Name)
                            .AsWcfClient(
                                new DefaultClientModel
                                    {
                                        Endpoint =
                                            WcfEndpoint.BoundTo(new WSHttpBinding(SecurityMode.Transport) { MaxReceivedMessageSize = int.MaxValue })
                                            .At(string.Format("https://{0}/{1}.svc", GetServerName(), x.Name.Substring(1)))
                                    })
                            .IsFallback()));
        }
