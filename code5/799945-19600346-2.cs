    /// <summary>
    /// Represents our program class which contains the entry point of our application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Represents the entry point of our application.
        /// </summary>
        /// <param name="args">Possibly spcified command line arguments.</param>
        public static void Main(string[] args)
        {
            // Print the number of arguments specified to the console.
            Console.WriteLine("There ha{0} been {1} command line argument{2} specified.",
                              (args.Length > 1 ? "ve" : "s"), 
                              args.Length,
                              (args.Length > 1 ? "s" : string.Empty));
            // Iterate trough all specified command line arguments
            // and print them to the console.
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Argument at index {0} is: {1}", i, args[i]);
            }
            // Wait for any key before exiting.
            Console.ReadKey();
        }
    }
