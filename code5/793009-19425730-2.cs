    public interface INonGen
    {
        void NonGenericMethod();
    }
    
    public interface IGen<T> : INonGen
    {
        void Get(ref T value);
    }
    
    public class Gen<T, U> : IGen<T> where U : T
    {
        private U u;
    
        public void Get(ref T value) 
        {
            if (value is U)
            {
                value = (T)u;
            }
            else
                throw new Exception();
        }
    
        public void NonGenericMethod()
        {
        }
    }
