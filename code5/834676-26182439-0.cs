    if( !channel.IsOpen || !connection.IsOpen )
    {
        Your_Connection_Channel_Init_Function();
        consumer = new QueueingBasicConsumer(channel);  // consumer is tied to channel
    }
    
    if( consumer.Queue.Count() > 0 )
        BasicDeliverEventArgs e = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
