    public abstract class Base<T> where T : Base<T>
    {
        public abstract T GetChild();
        protected Base(T parent, out string param)
        {
            param = ComplexComputation();
        }
        protected Base()
        {
        }
    }
    
    // --- somewhere else: ---
    
    public class Derivative : Base<Derivative>
    {
        public sealed override Derivative GetChild()
        {
            string param;
            return new Derivative(this, out param);
        }
        public Derivative() { }
    
        private Derivative(Derivative parent, out string param)
            : base(parent, out param)
        {
            // some configuration
        }
    }
