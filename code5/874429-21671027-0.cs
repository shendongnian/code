    public interface IDataProxy<T>
    {
        T Data { get; set; }
    }
    public class ViewModel<TProxy, TData>
        where TProxy : class, new, IDataProxy<TData>
    {
        public TProxy Proxy { get; private set; }
        public ViewModel(TData data)
        {
            Proxy = new TProxy { Data = data };
        }
    }
