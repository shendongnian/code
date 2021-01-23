    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var processor = new FileProcessor();
                processor.Run();
            }
            catch (RijException exception)
            {
                //what will I get here.
            }
        }
    }
