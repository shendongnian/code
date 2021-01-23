    /// <summary>
    /// Gets integer combinations between 0 and an exclusive upper bound.
    /// </summary>
    /// <param name="l">The length of the combination.</param>
    /// <param name="n">The exclusive upper bound.</param>
    /// <returns>
    /// All combinations of the specified length in the specified range.
    /// </returns>
    public static IEnumerable<IEnumerable<int>> Combinations(int l, int n)
    {
        var result = new int[l];
        var stack = new Stack<int>();
        stack.Push(0);
        while (stack.Count > 0)
        {
            var index = stack.Count - 1;
            var value = stack.Pop();
            while (value < n)
            {
                result[index++] = value++;
                stack.Push(value);
                if (index == 1)
                {
                    yield return result;
                    break;
                }
            }
        }
    }
