    while (!stopConsuming) {
        try {
            BasicDeliverEventArgs basicDeliverEventArgs;
            var messageIsAvailable = consumer.Queue.Dequeue(timeout, out basicDeliverEventArgs);
    
            if (!messageIsAvailable) continue;
                var payload = basicDeliverEventArgs.Body;
    
                var message = Encoding.UTF8.GetString(payload);
                OnMessageReceived(new MessageReceivedEventArgs {
                    Message = message,
                    EventArgs = basicDeliverEventArgs
                });
    
                if (implicitAck && !noAck) channel.BasicAck(basicDeliverEventArgs.DeliveryTag, false);
            }
            catch (Exception exception) {
                OnMessageReceived(new MessageReceivedEventArgs {
                    Exception = new AMQPConsumerProcessingException(exception)
                });
                if (!catchAllExceptions) Stop();
            }
        }
    }
