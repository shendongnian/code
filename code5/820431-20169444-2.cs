    public void Subscribe<TMessage>(IHandle<TMessage> handler)
    {
    [...]
    public interface IHandler<T>
    {
        Handle(T event);
    }
