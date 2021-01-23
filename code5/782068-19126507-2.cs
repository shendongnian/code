        static void Main(string[] args)
        {
            try
            {
                SqlPlayground.EntryPointStuff();
                Console.WriteLine("Press Enter after deleting the database in SSMS manually with 'Close Existing Connections' checked.");
                Console.ReadLine();
                SqlPlayground.EntryPointStuff();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Pressing Enter To End");
            Console.ReadLine();
        }
