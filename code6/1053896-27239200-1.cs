        public static T ConvertTo<T>(object value)
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch(Exception ex)
            {
                return (T)(typeof(T).IsValueType ? Activator.CreateInstance(typeof(T)) : null);
            }
            
        }
        static void Main(string[] args)
        {
            Console.Write("Enter int: ");
            int a = ConvertTo<int>(Console.ReadLine());
            Console.Write("Enter decimal: ");
            decimal b = ConvertTo<decimal>(Console.ReadLine());
            Console.Write("Enter double: ");
            double c = ConvertTo<double>(Console.ReadLine());
            Console.Write("Enter Date Time: ");
            DateTime d = ConvertTo<DateTime>(Console.ReadLine());
            Console.WriteLine(a + ", " + b + ", " + c + ", " + d);
        }
