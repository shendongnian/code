        static void Main(string[] args)
        {
            decimal p = 15.5m;
            int q = 5;
            Console.WriteLine(CompareTo<int, decimal, decimal>(q, p));
           
        }
  
        public static T3 CompareTo<T1, T2, T3>(T1 value1, T2 value2) 
            where T3:IComparable
        {
            T3 p = ConvertTo<T3>(value1);
            T3 q = ConvertTo<T3>(value2);
            if(p.CompareTo(q) >= 0)
            {
                return p;
            }
            else
            {
                return q;
            }
        }
        public static T ConvertTo<T>(object value)
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
            }
            catch(Exception ex)
            {
                return (T)(typeof(T).IsValueType ? Activator.CreateInstance(typeof(T)) : null);
            }
            
        }
