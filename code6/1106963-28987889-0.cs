    ae.Handle((x) =>
            {
                if (x is UnauthorizedAccessException) // This we know how to handle.
                {
                    Console.WriteLine("You do not have permission to access all folders in this path.");
                    Console.WriteLine("See your network administrator or try another path.");
                }
                return true; 
            });
