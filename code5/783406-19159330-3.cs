    private static List<int[]> SplitOnDirection(int[] input)
    {
        List<int[]> output = new List<int[]>();
        List<int> currentList = new List<int>();
        bool? isRaising = null;
        int? previousNumber = null;
        foreach (int number in input)
        {
            // do we have a previous value?
            if (previousNumber.HasValue)
            {
                // only if the number is different, then we have to check the direction.
                if (number != previousNumber.Value)
                {
                    bool isHigherNumber = (number > previousNumber.Value);
                    // do we already know if we start with raise/lowering
                    if (isRaising.HasValue)
                    {
                        // if we have a higher number and we're not raising, change direction.
                        if (isHigherNumber != isRaising.Value)
                        {
                            // We changed direction..
                            output.Add(currentList.ToArray());
                            currentList = new List<int>();
                        }
                    }
                    isRaising = isHigherNumber;
                }
            }
            previousNumber = number;
            currentList.Add(number);
        }
        // if we didn't changed direction, we should 'flush' these.
        if (currentList.Count > 0)
            output.Add(currentList.ToArray());
        return output;
    }
    int[] input = new int[] { 100, 200, 300, 400, 500, 600, 500, 400, 300, 200, 100, 500, 700, 800, 900 };
    List<int[]> output = SplitOnDirection(input);
