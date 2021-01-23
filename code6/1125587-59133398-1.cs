    class Program
    {
        static int intData = 0;
        static string stringData = string.Empty;
        
        public static void CallByValueForValueType(int data)
        {
            data = data + 5;
        }
        public static void CallByValueForRefrenceType(string data)
        {
            data = data + "Changes";
        }
        public static void CallByRefrenceForValueType(ref int data)
        {
            data = data + 5;
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
            stringData = string.Empty;
            CallByValueForRefrenceType(stringData);
            Console.WriteLine($"CallByValueForRefrenceType : {stringData}");
            intData = 0;
            CallByRefrenceForValueType(ref intData);
            Console.WriteLine($"CallByRefrenceForValueType : {intData}");
            stringData = string.Empty;
            CallByRefrenceForRefrenceType(ref stringData);
            Console.WriteLine($"CallByRefrenceForRefrenceType : {stringData}");
            Console.ReadLine();
        }
    }
