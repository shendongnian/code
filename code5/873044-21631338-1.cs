    public interface ISomeView
    {
    }
    public interface IView<out T> where T:class 
    {
        T SomeParam { get; }
    }
    public class SomeView:IView<ISomeView>
    {
        public ISomeView SomeParam { get; set; }
    }
    public class OneOfThoseView : ISomeView
    {
    }
    public class main
    {
        public main()
        {
            OneOfThoseView oneOfThose = new OneOfThoseView();
            SomeView x = new SomeView();
            x.SomeParam = oneOfThose;
        }
    }
