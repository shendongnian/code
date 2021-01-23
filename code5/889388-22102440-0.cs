    public interface IMyInterface
    {
        public object Value { get; set; }
    }
    public class C<T> where T:IMyInterface
