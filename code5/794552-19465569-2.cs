     public class Program<K> where K : IComparable, IFormattable, IConvertible, IComparable<K>, IEquatable<K>
    {
      static void Main()
      {  
            Program<int> pro = new Program<int>();
            Program<Byte> bpro = new Program<Byte>();
            Program<Double> dpro = new Program<Double>();
            Program<Int64> fpro = new Program<Int64>();
            Program<long> lpro = new Program<long>();
            Program<short> spro = new Program<short>();
       }
