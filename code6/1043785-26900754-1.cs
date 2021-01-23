    /// <summary>
    /// Gets the value of the item in the list of
    /// numbers that is closest to the given number
    /// </summary>
    /// <param name="number">Any number</param>
    /// <param name="numbers">A list of numbers, sorted from lowest to highest,
    /// where the difference between each item is the same</param>
    /// <returns>The value of the list item closest to the given number</returns>
    public static int GetClosestNumber(int number, List<int> numbers)
    {
        if (numbers == null) throw new ArgumentNullException("numbers");
        if (numbers.Count == 1) return 1; // Short-circuit if list is only one item
        var step = Math.Abs(numbers[1] - numbers[0]);
        // Get closest number using a slight modification of AlexD's elegant solution
        var closestNumber = (Math.Abs(number) + (step / 2)) / step * 
            step * (number < 0 ? -1 : 1);
        // Ensure numbers is within min/max bounds of the list
        return Math.Min(Math.Max(closestNumber, numbers[0]), numbers[numbers.Count - 1]);
    }
