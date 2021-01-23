    public sealed class TestHub
      : Hub<ITestClient>
    {
      public override Task OnConnected()
      {
        this.Clients.Caller.SayHello("Hello from OnConnected!");
        return base.OnConnected();
      }
      public void Hi()
      {
        // Say hello back to the client when client greets the server.
        this.Clients.Caller.SayHello("Well, hello there!");
      }
    }
    public interface ITestClient
    {
      void SayHello(String greeting);
    }
