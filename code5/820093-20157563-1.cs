    string input = Console.ReadLine();
        
    if (input.Length == 7)
    {
        if (!input.StartsWith("555"))
        {
            if (input[0] != '0')
            {
                int temp;
                if (!int.TryParse(input[0].ToString(), out temp)
                {
                }
                else
                {
                    // first char is not an int
                }
            }
            else
            {
               // first char is 0 error
            }
        }
        else
        {
             /// 555 error
        }
    }
    else
    {
             // wrong amount of digits
    
    }
