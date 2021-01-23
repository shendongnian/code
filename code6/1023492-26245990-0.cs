    /// <summary>
    /// determine number of combining characters in string
    /// </summary>
    /// <param name="input"><see cref="System.String"/>string to check</param>
    /// <returns>integer</returns>
    public static int NumberOfCombiningCharacters(this string input)
    {
        return input.Where(c => c >= 768 && c <= 879).Count();            
    }
