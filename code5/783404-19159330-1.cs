    private static List<List<int>> SplitOnDirection(IEnumerable<int> input)
    {
        List<List<int>> output = new List<List<int>>();
        List<int> currentList = new List<int>();
        bool? isRaising = null;
        int? previousNumber = null;
        foreach (int number in input)
        {
            // do we have a preivious value?
            if (previousNumber.HasValue)
            {
                bool raising = (number > previousNumber.Value);
                // do we already know if we start with raise/lowering
                if (isRaising.HasValue)
                {
                    if (raising != isRaising.Value)
                    {
                        output.Add(currentList);
                        currentList = new List<int>();
                    }
                }
                isRaising = raising;
            }
            previousNumber = number;
            currentList.Add(number);
        }
        if (currentList.Count > 0)
            output.Add(currentList);
        return output;
    }
    int[] input = new int[] { 100, 200, 300, 400, 500, 600, 500, 400, 300, 200, 100, 500, 700, 800, 900 };
    List<List<int>> output = SplitOnDirection(input);
