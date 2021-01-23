    internal class Program
    {
        private static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            var rabbitMqConnection = "rabbitmq://localhost";
            var consumers = new[] { typeof(ExampleConsumer) };
    
            var configurator = new MassTransitConfigurator(
                    rabbitMqConnection,
                    MassTransitConfigurator.Queue.Worker,
                    kernel,
                    consumers);
    
            configurator.Configure();
        }
    }
