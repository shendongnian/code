        public interface ICommandHandler<out TCommand, out TMessageResult>
            where TCommand : ICommand
            where TMessageResult : IMessageResult
        { }
        
        // register this way
        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsClosedTypesOf(typeof(ICommandHandler<,>))
                .As<ICommandHandler<ICommand, IMessageResult>>();
        // resolve this ways
        var commandHandlers = container.Resolve<IEnumerable<ICommandHandler<ICommand, IMessageResult>>>();
        Console.WriteLine(commandHandlers.Count());
