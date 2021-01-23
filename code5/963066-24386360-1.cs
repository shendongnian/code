    public async Task DoSomething() {
      using (new IgnoreSynchronizationContext())
      {
        var client = new SmtpClient();
        var message = new MailMessage(/* setup message here */);
        await client.SendMailAsync(message);
      }
    }
    public sealed class IgnoreSynchronizationContext : IDisposable
    {
      private readonly SynchronizationContext _original;
      public IgnoreSynchronizationContext()
      {
        _original = SynchronizationContext.Current;
        SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
      }
      public void Dispose()
      {
        SynchronizationContext.SetSynchronizationContext(_original);
      }
    }
