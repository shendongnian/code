    public class CreateCommandBaseHandler<TCommand, TModel> 
        : ICommandHandler<TCommand, TModel> // no nested generic arguments here
        where TCommand : CreateBaseCommand<TModel> // but type constraint here.
    {
        public TModel Handle(TCommand command)
        {
            // create the thing
            return default(TModel);
        }
    }
    public class DeleteCommandBaseHandler<TCommand, TModel> 
        : ICommandHandler<TCommand, TModel>
        where TCommand : DeleteBaseCommand<TModel>
    {
        public TModel Handle(TCommand command)
        {
            // delete the thing
            return default(TModel);
        }
    }
