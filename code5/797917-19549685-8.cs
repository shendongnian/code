    public static void RemoveAll<T>(this LinkedList<T> list, Func<T, bool> predicate)
    {
        var currentNode = list.First;
        while (currentNode != null)
        {
            if (predicate(currentNode.Value))
            {
                var toRemove = currentNode;
                currentNode = currentNode.Next;
                list.Remove(toRemove);
            }
            else
            {
                currentNode = currentNode.Next;
            }
        }
    }
