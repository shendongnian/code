    static HashSet<T> TransitiveClosure<T>(
        this Func<T, IEnumerable<T>> relation,
        T item)
    {
        var closure = new HashSet<T>();
        var stack = new Stack<T>();
        stack.Push(item);
        while (stack.Count > 0)
        {
            T current = stack.Pop();
            foreach (T newItem in relation(current))
            {
                if (!closure.Contains(newItem))
                {
                    closure.Add(newItem);
                    stack.Push(newItem);
                }
            }
        }
        return closure;
    }
    static HashSet<T> TransitiveAndReflexiveClosure<T>(
        this Func<T, IEnumerable<T>> relation,
        T item)
    {
        var closure = TransitiveClosure(relation, item);
        closure.Add(item);
        return closure;
    }
