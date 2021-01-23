    public static IEnumerable<LinkedListNode<T>> Nodes<T>(this LinkedList<T> list)
    {
        if (list.Count == 0) yield break;
        else if (list.Count == 1)
        {
            yield return list.First;
        }
        else
        {
            for (var node = list.First; node != list.Last; node = node.Next)
            {
                yield return node;
            }
            yield return list.Last;
        }
    }
