    public static IEnumerable<T> Traverse<T>(T item, 
        Func<T, IEnumerable<T>> childSelector)
    {
        var stack = new Stack<T>();
        stack.Push(item);
        while (stack.Any())
        {
            var next = stack.Pop();
            yield return next;
            foreach (var child in childSelector(next))
                stack.Push(child);
        }
    }
---
    var allValues = Traverse(rootNode, node => node.Children)
        .Select(node => node.Value);
