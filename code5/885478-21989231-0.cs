    public IEnumerable<string> GetDifferences(List<string> list1, List<string> list2)
    {
        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i]) yield return list1[i];
        }
    }
