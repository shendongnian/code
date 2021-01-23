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
            Console.Write("Enter value: ");
            int a = ConvertTo<int>(Console.ReadLine());
            Console.WriteLine(a);
        }
