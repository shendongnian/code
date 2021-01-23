    public interface IA
    {
        string StringA { get; }
    }
    public interface IB
    {
            string StringA { get; }
    }
    public class B
    {
        public string StringA { get; }
    }
    public class A : B, IA, IB
    {
        public string StringA
        {
            get
            {
                return "A";
            }
        }
        string IB.StringA
        {
            get
            {
                return "B";
            }
        }
    }
