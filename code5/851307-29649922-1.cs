    container = new UnityContainer();
            MassTransit.Log4NetIntegration.Logging.Log4NetLogger.Use();
            // Register the ServiceBus to our container.
            container.RegisterInstance<IServiceBus>(ServiceBusFactory.New(sbc =>
            {
                sbc.UseMsmq();
                sbc.ReceiveFrom("msmq://localhost/Mt_Msmq_Saga_Unity");
                sbc.SetConcurrentConsumerLimit(100);
                sbc.UseControlBus();
                sbc.SetCreateMissingQueues(true);
                sbc.SetPurgeOnStartup(true);
                //sbc.UseMulticastSubscriptionClient();
                sbc.Subscribe(subs =>
                {
                    subs.LoadFrom(container);
                    subs.Saga<RfqSubmittedSaga>(new NHibernateSagaRepository<RfqSubmittedSaga>(Fluently
                        .Configure()
                        .Database(
                            MsSqlConfiguration.MsSql2012
                                .AdoNetBatchSize(100)
                                .ConnectionString(s => s.Is("Server=192.168.0.2\\SQL2012EXP;initial catalog=MTSaga; User Id=sa; Password=mypassword;"))
                                .DefaultSchema("dbo")
                                .Raw(NHibernate.Cfg.Environment.Isolation, IsolationLevel.Serializable.ToString()))
                        .ProxyFactoryFactory("NHibernate.Bytecode.DefaultProxyFactoryFactory, NHibernate")
                        .Mappings(m =>
                        {
                            // Tell Fluent NHibernate about our mapping to store the Saga.
                            m.FluentMappings.Add<RfqSubmittedSagaMap>();
                        })
                        .ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, true))
                        .BuildSessionFactory())).Permanent();
                });
            }));
