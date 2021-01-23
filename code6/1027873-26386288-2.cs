    public static void SetSolution(string newSolution)
    {
        solution = new sbyte[newSolution.Length];
        // Loop through each character of our string and save it in our byte
        // array
        for (int i = 0; i < newSolution.Length; i++)
        {
            string character = newSolution.Substring(i, 1); 
            if (character.Contains("0") || character.Contains("1"))
            {
                solution[i] = SByte.Parse(character);
            }
            else
            {
                solution[i] = 0;
            }
        }
    }
