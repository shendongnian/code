    public int[] OrderedArray(int[] numbers)
    {
        int[] final = new int[numbers.Length];
        int last = numbers.Length - 1;
        var finalCounter = 0;
        for (int i = 0; finalCounter < numbers.Length; i++)
        {
            final[finalCounter] = numbers[i];
            final[finalCounter + 1] = numbers[last];
            finalCounter += 2; ;
            last--;
        }
        return final;
    }
