    class Program
    {
        static void Main(string[] args)
        {
            decimal dec = new Decimal(33);
            object o = (object)dec;
            double dd = GetValue<double>(o);
            Console.WriteLine(dd);
        }
        static T GetValue<T>(object val)
        {
            return (T)Convert.ChangeType(val, typeof(T));
        }
    }
