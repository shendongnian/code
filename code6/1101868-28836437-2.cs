    public interface ICommandResponse
    {
        bool Success { get; }
        IReadOnlyCollection<string> Errors { get; }
    }
    
    public class CommandResponse : ICommandResponse
    {
        public bool Success { get; set; }
        public IReadOnlyCollection<string> Errors { get; set; }
    }
    
    public interface ICommand<in TModel>
    {
        ICommandResponse Handle(TModel model);
    }
    
    public abstract class CommandBase<TModel> : ICommand<TModel>
    {
        public abstract ICommandResponse Handle(TModel model);
    
        protected ICommandResponse Success()
        {
            return new CommandResponse { Success = true };
        }
        
        protected ICommandResponse Fail(params string[] errors)
        {
            return new CommandResponse { Errors = new ReadOnlyCollection<string>(errors) };
        }
    }
