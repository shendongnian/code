     class Program
        {
            static void Main(string[] args)
            {
                ArithmeticOperation.ArOpDel additionDelegate = ArithmeticOperation.Addition;
                
                Console.WriteLine(ArithmeticOperation.ConvertResultToString(additionDelegate,5,6));
                Console.ReadKey();
            }
        }
        public static class ArithmeticOperation
        {
            public delegate int ArOpDel(int x, int y);
    
            public static string ConvertResultToString(ArOpDel del,int x, int y )
            {
                string result = String.Format("The result of the {0} operation is {1}", del.Method.Name, del(x,y).ToString());
                return result;
            }
    
            public static int Addition(int x, int y)
            {
                return x + y;
            }
    
            public static int Subtraction(int x, int y)
            {
                return x - y;
            }
    
            public static int Multiplication(int x, int y)
            {
                return x * y;
            }
    
            public static int Division(int x, int y)
            {
                return x / y;
            }
        }
