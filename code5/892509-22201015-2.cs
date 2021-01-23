    // Made return type generic, and improved the name
    public IEnumerable<Car> GetTheCars(bool reverseOrder)
    {
        return reverseOrder ? GetTheCarsReversed() : carArray;
    }
    private IEnumerable<Car> GetTheCarsReversed()
    {
        for (int i = carArray.Length; i != 0; i--)
        {
            yield return carArray[i - 1];
        }
    }
