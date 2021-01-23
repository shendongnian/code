    Char[] digitsOnly = "3e317188a00577".Where(Char.IsDigit).ToArray();
    if(digitsOnly.Length > 0)
    {
        long result;
        if (long.TryParse(new string(digitsOnly), out result))
        {
            Console.Write("Successfully parsed to: " + result);
        }
    }
