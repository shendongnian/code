    class Program
    {
        static void Main(string[] args)
        {
            dynamic objArr = new object[0];
            dynamic intArr = new int[0];
            int[] typedIntArr = new int[0];
            string arrS = "[1,2]";
            Serialize(objArr, arrS); // dynamic call site
            Serialize(intArr, arrS); // dynamic call site
            Serialize(typedIntArr, arrS); // regular static call
        }
        public static object Serialize<T>(T targetFieldForSerialization, string value)
        {
            Console.WriteLine("Type: " + typeof(T).Name);
            return value.FromJson<T>();
        }
    }
