    public class Hello1
    {
        public static void Main()
        {
            try
            {
                // whatever
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception!);
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.Write("Press ENTER to exit: ");
                Console.ReadLine();
            }
        }
    }
