    private readonly BufferBlock<RabbitMQ.Client.Events.BasicDeliverEventArgs> _queue = new BufferBlock<RabbitMQ.Client.Events.BasicDeliverEventArgs>();
    public void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, RabbitMQ.Client.IBasicProperties properties, byte[] body)
    {
        RabbitMQ.Client.Events.BasicDeliverEventArgs e = new RabbitMQ.Client.Events.BasicDeliverEventArgs(consumerTag, deliveryTag, redelivered, exchange, routingKey, properties, body);
        _queue.Post(e);
    }
    public Task<RabbitMQ.Client.Events.BasicDeliverEventArgs> DequeueAsync(CancellationToken cancellationToken)
    {
        return _queue.ReceiveAsync(cancellationToken);
    }
