        static void Main(string[] args)
        {
            // The length of the pyramid
            int lengte = 18;
            // Loop through the length as given by the user
            for (int i = 0; i <= lengte; i++)
            {
                // If its an even number (we don't want 1-2-3.. but 1-3-5.. stars)
                if (i % 2 == 0)
                {
                    // Calculate the length of the spaces we need to set
                    int spatieLengte = (lengte / 2) - (i / 2);
                    // Display spaces
                    for (int spaties = 0; spaties <= spatieLengte; spaties++)
                    {
                        Console.Write(" ");
                    }
                    // Display stars
                    for (int sterren = 0; sterren <= i; sterren++)
                    {
                        Console.Write("*");
                    }
                    // Newline
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
