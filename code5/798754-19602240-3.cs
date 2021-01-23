    public class Dispatcher : IDispatcher {
    
      public TReply Send<TReply>(Query query) where TReply : Reply, new() {
          //(Snip) No changes to the original code
      } // Send
    
      public Task<TReply> SendAsync<TReply>(Query query) where TReply : Reply, new() {
           return Task.Run(() => Send<TReply>(query));
      } // SendAsync
    }
