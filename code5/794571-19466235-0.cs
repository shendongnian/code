    public interface ITest<T>
    {
        Type ReturnType { get; }//redundatnt
        T MyMethod(params object[] args);
    }
    public class Test : ITest<long>
    {
        public Type ReturnType { get { return typeof(long); } }//redundatnt
        public long MyMethod(params object[] args)
        {
            long sum = 0;
            foreach (long arg in args)
            {
                sum += arg;
            }
            return sum;
        }
    }
    Test test = new Test();
    long result = test.MyMethod(1,2,3,4);//No transform nothing, everything is clear
