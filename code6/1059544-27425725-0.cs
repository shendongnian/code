    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new UserAlreadyLoggedInException("Hello");
            }
            catch (Exception e)
            {
                Console.WriteLine("My handled exception: {0}", e.Message);
            }
        }
    }
    
    public class UserAlreadyLoggedInException : Exception
    {
        public UserAlreadyLoggedInException(string message) : base(message)
        {
            Console.WriteLine("Here");
        }    
    }
