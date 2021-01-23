    public interface IRegesterable
    {
        void Register();
    }
    public class Widget : IRegesterable
    {
        public void Register()
        {
            // do stuff
        }
    }
    public class Class1
    {
        public Class1(IRegesterable widget)
        {
            widget.Register();
        }
    }
