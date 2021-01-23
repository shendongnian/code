        static void Main()
        {
            try
            {
                Task demoTask = DoDemosAsync();
                demoTask.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.Write("\nPress any key to close console window...");
            Console.ReadKey(true);
        }
