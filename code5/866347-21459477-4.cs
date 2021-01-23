    public static IEnumerable<IEnumerable<T>> Permutations<T>(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            var head = new List<T>() { item };
            var subLists = Permutations(items.Except(head));
            if (subLists.Any())
            {
                foreach (var subList in subLists)
                {
                    yield return head.Concat(subList);
                }
            }
            else
            {
                yield return head;
            }
        }
    }
