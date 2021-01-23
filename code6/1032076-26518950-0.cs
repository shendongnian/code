    /// <summary>
    /// Converts an integer to a string, and adds leading spaces
    /// </summary>
    /// <param name="number">The number to convert</param>
    /// <param name="idealWidth">The ideal width the number should be. 
    /// If you only expect 3-digit numbers, then idealWidth should be 3.</param>
    /// <returns>Converted number with leading spaces. If the number of digits in
    /// "number" is equal to or greater than idealWidth, no padding is added</returns>
    public string PadNumber(int number, int idealWidth)
    {
        var paddedNumber = number.ToString();
        while(paddedNumber.Length < idealWidth)
        {
            paddedNumber = " " + paddedNumber;
        }
        return paddedNumber;
    }
