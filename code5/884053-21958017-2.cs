    public class MassTransitConfigurator
    {
        private readonly string _rabbitMqConnection;
        private readonly Queue _queue;
        private readonly IKernel _kernel;
        private readonly IEnumerable<Type> _consumers;
        private readonly IEnumerable<Type> _massTransitConsumers;
    
        public enum Queue
        {
            Worker,
            WorkerProducer,
        }
    
        public MassTransitConfigurator(string rabbitMqConnection, Queue queue, IKernel kernel,
            IEnumerable<Type> consumers)
        {
            _rabbitMqConnection = rabbitMqConnection;
            _queue = queue;
            _kernel = kernel;
            _consumers = consumers;
            if (_queue == Queue.Worker)
                _massTransitConsumers = _consumers.Select(GetMassTransitConsumer);
        }
    
        public void Configure()
        {
            if (_queue == Queue.Worker)
            {
                foreach (var consumer in _consumers)
                    _kernel.Bind(consumer).ToSelf();
                foreach (var massTransitConsumer in _massTransitConsumers)
                    _kernel.Bind(massTransitConsumer).ToSelf();
            }
    
            var massTransitServiceBus = ServiceBusFactory.New(ConfigureMassTransit);
            var ourServiceBus = new MassTransitServiceBus(massTransitServiceBus);
            _kernel.Bind<OurDomain.IServiceBus>().ToConstant(ourServiceBus);
        }
    
        private void ConfigureMassTransit(ServiceBusConfigurator config)
        {
            config.UseRabbitMq();
            var queueConnection = _rabbitMqConnection + "/" + _queue;
            config.ReceiveFrom(queueConnection);
    
            if (_queue == Queue.Worker)
            {
                foreach (var massTransitConsumer in _massTransitConsumers)
                {
                    var consumerType = massTransitConsumer;
                    config.Subscribe(s => s.Consumer(consumerType, t => _kernel.Get(t)));
                }
            }
        }
    
        private static Type GetMassTransitConsumer(Type domainConsumer)
        {
            var interfaceType = domainConsumer.GetInterface(typeof (IConsume<>).Name);
            if (interfaceType == null)
                throw new ArgumentException("All consumers must implement IConsume<>.", "domainConsumer");
    
            var messageType = interfaceType.GetGenericArguments().First();
    
            var massTransitConsumer = typeof (MassTransitConsumer<,>).MakeGenericType(messageType, domainConsumer);
    
            return massTransitConsumer;
        }
    }
