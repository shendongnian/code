                try
                {
                    handler.Handle(order);
                }
                catch (Exception exception)
                {
                    ILogger logger = ObjectFactory.GetInstance<ILogger>();
                    logger.Send(exception);
    #if DEBUG
                    throw;
    #endif
                }
