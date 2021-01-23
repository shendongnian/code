    public class UnaryOperator
    {
        private int Number1;
        private int Number2;
        private int Result;
        public UnaryOperator() { }
        public UnaryOperator(int number1, int number2)
        {
            Number1 = number1;
            Number2 = number2;
        }
        public static UnaryOperator operator +(UnaryOperator opr)
        {
            opr.Result = opr.Number1 + opr.Number2;  // Change this line
            return opr;
        }
        public void showdata()
        {
            Console.WriteLine("The Sum of Two Numbers is : " + Result);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            UnaryOperator opr = new UnaryOperator(20, 30);
            opr = +opr;  // Add this statement
            opr.showdata();
            Console.ReadLine();
        }
    }
