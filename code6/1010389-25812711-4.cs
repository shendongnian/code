    public void GetValidIndexForArrayFromRandomIndex(int index, string[] myArray)
    {
        var upperBound = myArray.GetUpperBound(0);
        var lowerBound = myArray.GetLowerBound(0);
        while (index > upperBound)
        {
            index -= upperBound + 1;
        }
        while (index < lowerBound)
        {
            index += upperBound;
        }
        return index;
    }
