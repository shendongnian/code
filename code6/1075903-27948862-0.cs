    public void ProcessCommand(object command) {
        using (this.container.BeginLifetimeScope()) {
            Type handlerType = 
                typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = container.GetInstance(handlerType);
            handler.Handle((dynamic)command);
        }
    }
