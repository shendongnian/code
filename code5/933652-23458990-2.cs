    static void Traverse<T>(Tree<T> node, Action<T> action) 
    {
        Parallel.ForEach(node, action);
    }
    //Elsewhere
    class Tree<T> : IEnumerable<T>
    {
        Tree<T> Left { get; set; }
        Tree<T> Right { get; set; } 
        T Data { get; set; }
        public IEnumerator<T> GetEnumerator()
        {
            yield return this.Data;
            if (Left != null)
            {
                foreach (var left in Left)
                {
                    yield return left.Data;
                }
            }
            if (Right != null)
            {
                foreach (var right in Right)
                {
                    yield return right.Data;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
