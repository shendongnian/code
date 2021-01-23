    string startingNumber = "9999903040404"; // "100023";
    int numberOfCharactersToRemove = 3;
                
    string endingNumber = string.Empty;
    int endingNumberLength = startingNumber.Length - numberOfCharactersToRemove;
                
    while (endingNumber.Length < endingNumberLength)
    {
        if (string.IsNullOrEmpty(endingNumber))
        {
            // Find the smallest digit in the starting number
            for (int i = 1; i <= 9; i++)
            {
                if (startingNumber.Contains(i.ToString()))
                {
                    endingNumber += i.ToString();
                    startingNumber = startingNumber.Remove(startingNumber.IndexOf(i.ToString()), 1);
                    break;
                }
            }
        }
        else if (startingNumber.Contains("0"))
        {
            // Add any zeroes
            endingNumber += "0";
            startingNumber = startingNumber.Remove(startingNumber.IndexOf("0"), 1);
        }
        else
        {
            // Add any remaining numbers from least to greatest
            for (int i = 1; i <= 9; i++)
            {
                if (startingNumber.Contains(i.ToString()))
                {
                    endingNumber += i.ToString();
                    startingNumber = startingNumber.Remove(startingNumber.IndexOf(i.ToString()), 1);
                    break;
                }
            }
        }
    }
    
    Console.WriteLine(endingNumber);
