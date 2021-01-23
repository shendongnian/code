    public bool Test(string input, string[] possibleValues)
    {
        int operationsCount = 0;
        if (input.Length != possibleValues.Length)
        {
            return false;
        }
        for (int i = 0; i < input.Length; i++)
        {
            bool found = false;
            for (int j = 0; j < possibleValues[i].Length; j++)
            {
                operationsCount++;
                if (input[i] == possibleValues[i][j])
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Value does not satisfies the condition. Number of operations: " + operationsCount);
                return false;
            }
        }
        Console.WriteLine("Value satisfies the condition. Number of operations: " + operationsCount);
        return true;
    }
    Test("0247", new string[] { "01", "23", "45", "67" });
