    private static string detectInput(string Input )
    {
        string result= Input;
        while (!((result == "exit") || (result == "query") || (result == "disable")));
        {            
                Console.WriteLine("invalid input detected. Please try again.");
                result= Console.ReadLine();
            }
        }
        result = readInput(result);
        
        return result;
    }
