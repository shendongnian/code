    class Program
     {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Start");
            try
            {
                System.Console.WriteLine("Try");
                throw new Exception("ttt");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Catch");
                throw;
            }
            finally
            {
                System.Console.WriteLine("Finally");
            }
        }
