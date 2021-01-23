    public interface ISomeView
    {
    }
    public interface IView<out T> where T:class 
    {
        T SomeParam { get; }
    }
    public class SomeView:IView<ISomeView>
    {
        public ISomeView SomeParam { get; private set; }
    }
