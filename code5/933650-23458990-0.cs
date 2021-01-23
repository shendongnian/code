    static void Traverse<T>(Tree<T> node, Action<T> action) 
    {
        Parallel.ForEach(node, action);
    }
    //Elsewhere
    class Tree<T> : IEnumerable<Tree<T>>
    {
        Tree<T> Left { get; set; }
        Tree<T> Right { get; set; } 
        public IEnumerator<Tree<T>> GetEnumerator()
        {
            yield return this;
            if (Left != null)
            {
                foreach (var left in Left)
                {
                    yield return left;
                }
            }
            if (Right != null)
            {
                foreach (var right in Right)
                {
                    yield return right;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
