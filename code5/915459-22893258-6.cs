    public class Program
    {
        static void Main(string[] args)
        {
            // Declare the first UnaryOperator object.
            UnaryOperator opr1 = new UnaryOperator(20, 30);
            // Declare the second UnaryOperator object.
            UnaryOperator opr2 = new UnaryOperator(10, 40);
            // Add them using the overloaded version of the + operator
            UnaryOperator result = opr1+opr2;
            // Show the results
            result.ShowData();
            Console.ReadLine();
         }
    }
