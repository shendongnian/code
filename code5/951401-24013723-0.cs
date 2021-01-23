    public static class Ext
    {
        public static void ForEachNested<T>(
            this IEnumerable<IEnumerable<T>> sources,
            Action<IEnumerable<T>> action)
        {
            var enumerables = sources.ToArray();
            Stack<IEnumerator<T>> fe = new Stack<IEnumerator<T>>();
            fe.Push(enumerables[0].GetEnumerator());
            while (fe.Count > 0)
            {
                if (fe.Peek().MoveNext())
                {
                    if (fe.Count == enumerables.Length)
                        action(new Stack<T>(fe.Select(e => e.Current)));
                    else
                        fe.Push(enumerables[fe.Count].GetEnumerator());
                }
                else
                {
                    fe.Pop().Dispose();
                }
            }
        }
    }
