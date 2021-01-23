    class Program
    {
        static int intData = 0;
        static string stringData = string.Empty;
        
        public static void CallByValueForValueType(int data)
        {
            data = data + 5;
        }
        public static void CallByValueForRefrenceType(ref int data)
        {
            data = data + 5;
        }
        public static void CallByRefrenceForValueType(string data)
        {
            data = data +"Changes";
        }
        public static void CallByRefrenceForRefrenceType(ref string data)
        {
            data = data  +"Changes";
        }
        static void Main(string[] args)
        {
            intData = 0;
            CallByValueForValueType(intData);
            Console.WriteLine($"CallByValueForValueType : {intData}");
            intData = 0;
            CallByValueForRefrenceType(ref intData);
            Console.WriteLine($"CallByValueForRefrenceType : {intData}");
            stringData = string.Empty;
            CallByRefrenceForValueType(stringData);
            Console.WriteLine($"CallByRefrenceForValueType : {stringData}");
            stringData = string.Empty;
            CallByRefrenceForRefrenceType(ref stringData);
            Console.WriteLine($"CallByRefrenceForRefrenceType : {stringData}");
            Console.ReadLine();
        }
    }
