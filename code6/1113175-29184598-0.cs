    int[] input = { -9, -7, -3, 1, 6, 8, 14 };
    int[] output = new int[input.Length];
    int negativeIndex, positiveIndex = 0, outputIndex = 0;
    while (input[positiveIndex] < 0)
    {
        positiveIndex++;
    }
    negativeIndex = positiveIndex - 1;
    while (outputIndex < output.Length)
    {
        if (negativeIndex < 0)
        {
            output[outputIndex++] = input[positiveIndex++];
        }
        else if (positiveIndex >= input.Length)
        {
            output[outputIndex++] = input[negativeIndex--];
        }
        else
        {
            output[outputIndex++] = -input[negativeIndex] < input[positiveIndex] ? input[negativeIndex--] : input[positiveIndex++];
        }
    }
    Console.WriteLine(string.Join(", ", output));
