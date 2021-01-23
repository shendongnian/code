    public static char GetLetter(string prompt)
                {
                    char result;
        
                    Console.Write("\n\t" + prompt + ":  ");
                    result = Console.ReadKey().KeyChar;
        
                    if (result == '!' || result == '@' || result == '#' || result == '$' || result == '%')
                    // we can keep going with all the unwanted characters and numbers 
                    {
                        Console.WriteLine("\n\t NO MATCH ! \n\t ,please try again using letters only , ");
                        result = GetLetter(prompt);
                        return result;
                    }
        
                    return result;
                }
