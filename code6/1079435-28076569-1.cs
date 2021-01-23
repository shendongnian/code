    public class Wrapper<T>
    {
        public T Value { get; set; }
    }
    Func<B, C> MakeFunctionBtoC(someVariables, Wrapper<Func<A, C>> AtoC)
    {
        return delegate(B b_in)
        {
           //... uses someVariables
           return b_in.getC() ?? AtoC.Value( b_in.getA() );
        }
    }
