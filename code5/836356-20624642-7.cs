    public interface IB<T> where T : IA
    {  
        List<T> SetA { get; set; }
        void MethodB1();
    }
    public class B : IB<A>
    {  
        public List<A> SetA {get; set; }
        public void MethodB1()
        {
                ...
                this.SetA = new List<A>();
                ...
        }
    }
