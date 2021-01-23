    class Program
    {
        static void Main(string[] args)
        {
            object objArr = new int[0];
            int[] intArr = new int[0];
            string arrS = "[1,2]";
    
            object objThatIsObjectArray = Serialize(objArr.GetType(), arrS);//this evaluates as int[]
            object objThatIsIntArray = Serialize(intArr.GetType(), arrS);//this evaluates as int[]
    
            Console.Read();
        }
        public static object Serialize<T>(Type type, string value)
        {
            return value.FromJson(type);
        }
    
    }
    
    public static class JSONExtensions
    {
        public static object FromJson(this string json, Type type)
        {
            using (var ms = new MemoryStream(Encoding.Default.GetBytes(json)))
            {
                var ser = new DataContractJsonSerializer(type);
                var target = ser.ReadObject(ms);
    
                ms.Close();
    
                return target;
            }
        }
    }
