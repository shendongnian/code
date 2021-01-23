    public static IEnumerable<int> GetEmptyIndexes(List<object> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == null)
            {
                yield return i;
            }
        }
    }
