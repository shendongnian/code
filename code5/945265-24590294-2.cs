    interface ICommand
    {
    }
    interface IRequest<out TRequest, out TResponse>
        where TRequest : ICommand //I will call it ICommand for now
        where TResponse : ICommand //For simplicity I will assume both TRequst and 
    {                              //TResponse are similar types.
        TRequest RequestItem { get; }
        TResponse ResponseItem{ get; }
        //whatever fits
    }
    class Request<TRequest, TResponse> : IRequest<TRequest, TResponse>
        where TRequest : ICommand 
        where TResponse : ICommand 
    {
    }
