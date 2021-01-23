            containerBuilder.Register(s =>
            {
                var factory = s.Resolve<ChannelFactory<IService>>();
                factory.Opening +=
                    (sender, args) =>
                        factory.Endpoint.Behaviors.Add(new SamsTrustBehaviour());
                return factory.CreateChannel();
            });
