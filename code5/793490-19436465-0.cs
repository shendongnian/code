    public interface ICommand {}
    public interface IContextOutput {}
    public interface IContext
    {
        IContextOutput Get(ICommand input);
    }
    public abstract class ContextBase<TInput, TOutput> : IContext		
        where TInput : ICommand
        where TOutput : IContextOutput
    {
        IContextOutput IContext.Get (ICommand input)
        {
            if (input.GetType () != typeof(TInput))
            {
                throw new ArgumentOutOfRangeException("input");
            }
            return Get((TInput)input);
        }
        protected abstract TOutput Get(TInput command);		
    }
