    class Tree<T> : IEnumerable<T>
    {
        Tree<T> Left { get; set; }
        Tree<T> Right { get; set; }
        T Data { get; set; }
        public IEnumerator<T> GetEnumerator()
        {
            Stack<Tree<T>> items = new Stack<Tree<T>>();
            //HashSet<Tree<T>> recursiveCheck = new HashSet<Tree<T>>();
            items.Push(this);
            //recursiveCheck.Add(this);
            while (items.Count > 0)
            {
                var current = items.Pop();
                yield return current.Data;
                if (current.Left != null)
                    //if(recursiveCheck.Add(current.Left))
                        items.Push(current.Left);
                if (current.Right != null)
                    //if (recursiveCheck.Add(current.Right))
                        items.Push(current.Right);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
