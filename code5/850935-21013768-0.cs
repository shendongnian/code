    public class MyBaseClass
    {
        public void PrintTheValue(long inputValue)
        {
            Console.WriteLine(" Printed from Base class method " + inputValue);
        }
    }
    public class MyDerivedClass : MyBaseClass
    {
        public void PrintTheValue(int inputValue)
        {
            Console.WriteLine(" Printed from Derived class method " + inputValue);
        }
    }
     static void Main(string[] args)
        {
            long longValue = 5;
            int intValue = 6;
            MyDerivedClass derivedObj = new MyDerivedClass();
            derivedObj.PrintTheValue(longValue);
            derivedObj.PrintTheValue(intValue);
            Console.Read();
        }
