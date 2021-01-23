        public class Multiply 
    {
            //Multiplies argument by 4 
            public static int MultiplyBy4(int aNumber)
            {
                return 4 * aNumber;
            }
     
            //Shows ways of passing various arguments to a method
            public static void Main(string[] args)
            {
                    int x = 7;
                    int y = 20;
                    int z = -3;
                    int result = 0;
    
                    result = MultiplyBy4(x);
                    Console.WriteLine("Passsing a variable, x : {0}", result);
    
                    result = MultiplyBy4(y + 2);
                    Console.WriteLine("Passing an expression, Y + 2: {0}", result);
    
                    result = 5 + MultiplyBy4(z);
                    Console.WriteLine("Using MultiplyBy4 in an expression: {0}", result);
                    Console.ReadLine();
                }
     }
