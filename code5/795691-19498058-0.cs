    namespace ConsoleApplication1
    {
        class AddClass1
        {
            public int val;
    
            public static AddClass1 operator +(AddClass1 p1, AddClass1 p2)
            {
                AddClass1 returnVal = new AddClass1();
                returnVal.val = p1.val + p2.val;
                return returnVal;
            }
    
            public static AddClass1 operator -(AddClass1 p1, AddClass1 p2)
            {
                AddClass1 returnVal = new AddClass1();
                returnVal.val = p1.val - p2.val;
                return returnVal;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                AddClass1 i = new AddClass1();
                i.val = 10;
                AddClass1 j = new AddClass1();
                j.val = 5;
                AddClass1 sum = i + j;
                AddClass1 difference = i - j;
    
                Console.WriteLine(sum.val);
                Console.WriteLine(difference.val);
                Console.ReadLine();
            }
        }
    }
