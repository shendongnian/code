    using (var mqFactory = appHost.TryResolve<IMessageFactory>())
    {
        var request = new ValidateTestMq { Id = -10 };
        mqFactory.CreateMessageProducer().Publish(request);
        var msg = mqFactory.CreateMessageQueueClient()
            .Get(QueueNames<ValidateTestMqResponse>.Dlq, null)
            .ToMessage<ValidateTestMqResponse>();
        Assert.That(msg.GetBody().ResponseStatus.ErrorCode,
            Is.EqualTo("PositiveIntegersOnly"));
        request = new ValidateTestMq { Id = 10 };
        mqFactory.CreateMessageProducer().Publish(request);
        msg = mqFactory.CreateMessageQueueClient()
             .Get(QueueNames<ValidateTestMqResponse>.In, null)
            .ToMessage<ValidateTestMqResponse>();
        Assert.That(msg.GetBody().CorrelationId, Is.EqualTo(request.Id));
    }
