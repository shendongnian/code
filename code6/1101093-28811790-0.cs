    int[] anArray= new int[] { 5, 40, 34, 5, 1, 2, 3, 4 };
    int lowerIndex = getLowerIndex(anArray);
    
    private int getLowerIndex(int[] input)
    {
        //create temp array
        int[] sortTab = new int[input.Length];
        //copy array
        for (int i = 0; i < input.Count(); i++)
        {
            sortTab[i] = input[i];
        }
        //copy array
        Array.Sort(sortTab);
        //get lower value 
        int lowerValue = sortTab[0];
        //get index of lower value
        int lowerIndex = Array.IndexOf(input, lowerValue);
        return lowerIndex;
    }
