    public static IEnumerable<IEnumerable<T>> Permutations<T>(IEnumerable<T> items)
    {
        if (items.Any())
        {
            foreach (var item in items)
            {
                var head = new List<T>() { item };
                var tail = items.Except(head);
                foreach (var subList in Permutations(tail))
                {
                    yield return head.Concat(subList);
                }
            }
        }
        else
        {
            yield return new List<T>();
        }
    }
