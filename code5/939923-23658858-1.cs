    public class MyService<TData, TDto> : IMyService<TData, TDto>
        where TData : class, IMyData, new()
        where TDto : class, IMyDto, new()
    {
        public TDto DoSomething(TData data)
        {
            return new TDto();
        }
    }
