    interface ICalc
    {
        int Sum(int x, int y);
    }
    abstract class AbsCalc
    {
        public abstract int Sum(int x, int y);
    }
    class Program : AbsCalc, ICalc
    {
        public override int Sum(int x, int y)
        {
            Console.WriteLine("From abstract Override");
            return x + y;
        }
        int ICalc.Sum(int x,int y)
        {
            Console.WriteLine("From Intrface");
            return x + y;
        }
        
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Sum(1, 2);
            ICalc i = p;
            i.Sum(1,2);
        }
    }
 
