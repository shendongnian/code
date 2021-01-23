    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> Leaves<TSource>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TSource>> children, Func<TSource, bool> isLeaf)
        {
            var nodes = new Stack<TSource>(source);
            while (nodes.Any())
            {
                var current = nodes.Pop();
                if(isLeaf(current))
                {
                    yield return current;
                    continue;
                }
                foreach (var child in children(current))
                {
                    if (isLeaf(child))
                    {
                        yield return child;
                    }
                    else
                    {
                        nodes.Push(child);
                    }
                }
            }
        }
    }
