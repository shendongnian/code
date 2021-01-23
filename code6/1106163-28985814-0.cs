        public interface ICommandHandler { }
        public interface ICommandHandler<TCommand, TMessageResult>
            : ICommandHandler
            where TCommand : ICommand
            where TMessageResult : IMessageResult
        { }
        
        // register it this way 
        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsClosedTypesOf(typeof(ICommandHandler<,>))
                .As<ICommandHandler>();
