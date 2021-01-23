    public IEnumerable<IEnumerable<int>> PowerSet(IEnumerable<int> initialSet)
    {
        foreach (IEnumerable<int> set in PowerSetRecursive(initialSet, initialSet.Count() - 1))
        {
            yield return set;
        }
    }
    private IEnumerable<IEnumerable<int>> PowerSetRecursive(IEnumerable<int> initialSet, int index)
    {
        if (index == 0)
        {
            yield return new int[] { };
            yield return new int[] { initialSet.ElementAt(index) };
        }
        else
        {
            foreach (IEnumerable<int> set in PowerSetRecursive(initialSet, index - 1))
            {
                yield return new HashSet<int>(set);
                yield return new HashSet<int>(set) { initialSet.ElementAt(index) };
            }
        }
    }
