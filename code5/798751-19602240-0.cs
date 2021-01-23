    public class Dispatcher : IDispatcher {
    
      public TReply Send<TReply>(Query query) where TReply : Reply, new() {
           //(Snip) No changes to the original code
      } // Send
    
      public async TReply SendAsync<TReply>(Query query) where TReply : Reply, new() {
    
        Type type = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TReply));
    
        IQueryHandler handler = (IQueryHandler)ObjectFactory.GetInstance(type);
    
        try {
    
          return await (TReply)handler.HandleAsync(query); //Uses the new method "Task<TResult> IQueryHandler<TQueryType, TResult>.HandleAsync(TQueryType query)"
    
        } catch (Exception exception) {
    
          ILogger logger = ObjectFactory.GetInstance<ILogger>();
          logger.Send(exception);
          if (Debugger.IsAttached) throw;
          return new TReply { Exception = exception };
    
        }
      } // Send
    }
