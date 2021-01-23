    interface IMessage //I will call it IMessage for now
    {
        //implement whatever that make deserializing possible
    }
    class FooRequest : IMessage
    {
    }
    class BarResponse : IMessage
    {
    }
    interface IRequest<out TRequest, out TResponse>
        where TRequest : IMessage 
        where TResponse : IMessage 
    {
        TRequest RequestItem { get; }
        TResponse ResponseItem { get; }
        //whatever fits, but only getters for out parameter types
    }
    class Request<TRequest, TResponse> : IRequest<TRequest, TResponse>
        where TRequest : IMessage 
        where TResponse : IMessage 
    {
        //you can extend interface properties with setters here
    }
