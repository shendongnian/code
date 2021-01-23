    //...... code from original question above to ....
    //declarations of MyData, IMyData, MyDto, IMyDto, MyService and IMyService 
    public interface IMyServiceFactory
    {
        IMyService<TData, TDto> GetService<TData, TDto>( )
            where TData : class, new()
            where TDto : class, new();
    }
    public class MyServiceFactory : IMyServiceFactory
    {
        public IMyService<TData, TDto> GetService<TData, TDto>( )
            where TData : class, new()
            where TDto : class, new()
        {
            return new MyService<TData, TDto>();
        }
    }
    public class TryToUse
    {
        private readonly IMyServiceFactory _serviceFactory;
        //The serviceFactory is normally created by dependency injection
        public TryToUse(IMyServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }
        public IMyDto UseService()
        {
            var boundService = _serviceFactory.GetService<MyData, MyDto>();
            return boundService.DoSomething(new MyData());
        }
    }
