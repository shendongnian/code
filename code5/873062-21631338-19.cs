    public interface ISomeView
    {
    }
    
    public abstract class BaseView<T> where T : BaseView<T>
    {
        public T SomeParam { get; set; }
    }
    public class SomeView : BaseView<SomeView>
    {
    }
