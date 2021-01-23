    await tasks.WhenAll(ConsumerAsync(), ConsumerAsync(), ConsumerAsync());
    async Task ConsumerAsync()
    {
      for (;;) // TODO: consider a CancellationToken for orderly shutdown
      {
        var m = await mq.ReceiveAsync();
        var c = GetCommand(m);
        await c.InvokeAsync();
        m.Delete();
      }
    }
    // Extension method
    public static Task<Message> ReceiveAsync(this MessageQueue mq)
    {
      return Task<Message>.Factory.FromAsync(mq.BeginReceive, mq.EndReceive, null);
    }
