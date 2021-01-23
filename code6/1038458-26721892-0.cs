    public interface IAbsNum<T>
    {
       T Abs(T num);
    }
    
    public class IntAbsNum : IAbsNum<int>
    {
        public int Abs(int num) { return Math.Abs(num); }
    }
