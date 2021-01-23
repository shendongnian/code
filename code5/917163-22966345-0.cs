    // Raise message received event
    var args = new MessageReceivedArgs();
    args.CorrelationId = response.BasicProperties.CorrelationId;
    args.Message = Encoding.UTF8.GetString(response.Body);
    args.Exchange = response.Exchange;
    args.RoutingKey = response.RoutingKey;
    
    if (response.BasicProperties.Headers != null && response.BasicProperties.Headers.ContainsKey("RequestType"))
    {
	args.RequestType = Encoding.UTF8.GetString((byte[])response.BasicProperties.Headers["RequestType"]);
    }
    
    MessageReceived(this, args);
    model.BasicAck(response.DeliveryTag, false);
