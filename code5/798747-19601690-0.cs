    public async Task<TReply> SendAsync<TReply>(Query query) where TReply : Reply, new()
    {
        return await Task.Run(() =>
        {
            Type type = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TReply));
            IQueryHandler handler = (IQueryHandler)ObjectFactory.GetInstance(type);
            try
            {
                return (TReply)handler.Handle(query);
            }
            catch (Exception exception)
            {
                ILogger logger = ObjectFactory.GetInstance<ILogger>();
                logger.Send(exception);
                if (Debugger.IsAttached) throw;
                return new TReply { Exception = exception };
            }
        }
    }
