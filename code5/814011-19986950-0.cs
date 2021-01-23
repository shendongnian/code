    private static int ParseNumber(string input)
    {
                 string cleanedInput = input.Where(c => char.IsDigit(c)).ToString();
                 int result;
                 if (!Int32.TryParse(cleanedInput, out result))
                 {
                    Console.WriteLine("An error occured..");
                 }
         return result;
    }
