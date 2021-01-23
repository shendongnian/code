    static private string CustomTakeSkip(string inputText, int numTakeSkip)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = numTakeSkip - 1; i < inputText.Length; i += numTakeSkip * 2)
        {
            int nextStringLength = i + numTakeSkip > inputText.Length ? inputText.Length - i : numTakeSkip;
            stringBuilder.Append(inputText.Substring(i, nextStringLength));
        }
        return stringBuilder.ToString();
    }
