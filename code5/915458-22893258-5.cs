    public class UnaryOperator
    {
        public int Number1 { get; set; } 
        public int Number2 { get; set; }
        
        public UnaryOperator(int number1, int number2)
        {
            Number1 = number1;
            Number2 = number2;
        }
        public static UnaryOperator operator +(UnaryOperator unaryOperator1, UnaryOperator unaryOperator2)
        {
            return new UnaryOperator(unaryOperator1.Number1+unaryOperator2.Number1,
                                 unaryOperator1.Number2+unaryOperator2.Number2);
        }
        public void ShowData()
        {
            Console.WriteLine("Number1: {0}, Number2: {1}", Number1, Number2);
        }
    }
