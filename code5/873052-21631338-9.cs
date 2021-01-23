    public interface ISomeView
    {
    }
    public abstract class BaseView<T> where T : class
    {
        public T SomeParam { get; set; }
    }
    public class SomeView : BaseView<ISomeView>{
    }
