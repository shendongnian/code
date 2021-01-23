    configuration.AssembliesToScan
                (typeof(SomeMessage).Assembly,
                 typeof(SomeHandler).Assembly,
                 typeof(RabbitMQTransport).Assembly,
                 typeof(RavenDBPersistence).Assembly);
