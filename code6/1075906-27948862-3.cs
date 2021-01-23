    public void ProcessCommand(object command) {
        using (AsyncScopedLifestyle.BeginScope(this.container)) {
            Type handlerType = 
                typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = container.GetInstance(handlerType);
            handler.Handle((dynamic)command);
        }
    }
