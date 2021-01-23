    public class Program
    {
        public static double Calculate(int x)
        {
            try
            {
                x = 2 / x;
            }
            catch (ArithmeticException ae)
            {
                try
                {
                    x = 2 / x;
                }
                catch(Exception ex1)
                {
                    Console.WriteLine("Message: " + ex1.Message);
                }
                Console.WriteLine("Message: " + ae.Message);
            }
            catch (Exception ex)
            {                
                Console.WriteLine("Message: " + ex.Message);
            }
            finally
            {
                x = 10;
            }
            return x;
        }
        static void Main(string[] args)
        {
            double myResult = Program.Calculate(0);
            Console.WriteLine(myResult);
        }
    }
}
