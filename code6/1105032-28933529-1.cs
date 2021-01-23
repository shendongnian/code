    public interface IFoo
    {
        int Bar { get; }
    }
    public class A : IFoo
    {
        int IFoo.Bar
        {
            get { return -1; }
        }
    }
