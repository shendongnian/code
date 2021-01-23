    public class DependencyExtensions
    {
        enum VisitState
        {
            NotVisited,
            Visiting,
            Visited
        };
        public static TValue ValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            TValue value;
            if (dictionary.TryGetValue(key, out value))
                return value;
            return defaultValue;
        }
        static void DepthFirstSearch<T>(T node, Func<T, IEnumerable<T>> lookup, List<T> parents, Dictionary<T, VisitState> visited, List<List<T>> cycles)
        {
            var state = visited.ValueOrDefault(node, VisitState.NotVisited);
            if (state == VisitState.Visited)
                return;
            else if (state == VisitState.Visiting)
            {
                // Do not report nodes not included in the cycle.
                cycles.Add(parents.Concat(new[] { node }).SkipWhile(parent => !EqualityComparer<T>.Default.Equals(parent, node)).ToList());
            }
            else
            {
                visited[node] = VisitState.Visiting;
                parents.Add(node);
                foreach (var child in lookup(node))
                    DepthFirstSearch(child, lookup, parents, visited, cycles);
                parents.RemoveAt(parents.Count - 1);
                visited[node] = VisitState.Visited;
            }
        }
        public static List<List<T>> FindCycles<T>(this IEnumerable<T> nodes, Func<T, IEnumerable<T>> edges)
        {
            var cycles = new List<List<T>>();
            var visited = new Dictionary<T, VisitState>();
            foreach (var node in nodes)
                DepthFirstSearch(node, edges, new List<T>(), visited, cycles);
            return cycles;
        }
        public static List<List<T>> FindCycles<T, TValueList>(this IDictionary<T, TValueList> listDictionary)
            where TValueList : class, IEnumerable<T>
        {
            return listDictionary.Keys.FindCycles(key => listDictionary.ValueOrDefault(key, null) ?? Enumerable.Empty<T>());
        }
    }
