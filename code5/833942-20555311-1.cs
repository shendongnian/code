    internal class Program
    {
        public interface Base
        {
            Int64 Size { get; }
        }
    
        public class Derived : Base
        {
            public Int64 Size
            {
                get
                {
                    return 10;
                }
            }
        }
    
        public class GenericProcessor<TT>
            where TT : Base
        {
            private Int64 sum;
    
            public GenericProcessor()
            {
                sum = 0;
            }
    
            public void process(TT o)
            {
                sum += o.Size;
            }
    
            public Int64 Sum
            {
                get
                {
                    return sum;
                }
            }
        }
    
        public class PolymorphicProcessor
        {
            private Int64 sum;
    
            public PolymorphicProcessor()
            {
                sum = 0;
            }
    
            public void process(Base o)
            {
                sum += o.Size;
            }
    
            public Int64 Sum
            {
                get
                {
                    return sum;
                }
            }
        }
    
        private static void Main(string[] args)
        {
            var generic_processor = new GenericProcessor<Derived>();
            var polymorphic_processor = new PolymorphicProcessor();
            Stopwatch sw = new Stopwatch();
            int N = 100000000;
            var derived = new Derived();
            sw.Start();
            for (int i = 0; i < N; ++i) polymorphic_processor.process(derived);
            sw.Stop();
            Console.WriteLine(
                "Sum =" + polymorphic_processor.Sum + " Poly performance = " + sw.ElapsedMilliseconds + " millisec");
            
    
            sw.Restart();
            sw.Start();
            for (int i = 0; i < N; ++i) generic_processor.process(derived);
            sw.Stop();
            Console.WriteLine(
                "Sum =" + generic_processor.Sum + " Generic performance = " + sw.ElapsedMilliseconds + " millisec");
    
            Console.Read();
        }
        }
