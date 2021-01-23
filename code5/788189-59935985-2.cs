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
                x = 2 / x;  // This will throw the error and programs terminates without returning any value.
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
