    public static IEnumerable<IEnumerable<T>> Permutations<T>(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            var head = new T[] { item };
            var tail = items.Except(head).ToList();
            var subLists = Permutations(tail);
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
