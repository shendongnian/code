    public static class IEnumerableExtensions
    {
        private class Node<T>
        {
            public Node()
            {
                Children = new List<Node<T>>();
            }
            public T Value
            {
                get;
                set;
            }
            public bool IsRoot
            {
                get;
                set;
            }
            public List<Node<T>> Children
            {
                get;
                private set;
            }
            public Node<T> Parent
            {
                get;
                set;
            }
            public List<Node<T>> Path
            {
                get
                {
                    List<Node<T>> Result = new List<Node<T>>();
                    Result.Add(this);
                    if (this.Parent.IsRoot == false)
                    {
                        Result.AddRange(this.Parent.Path);
                    }
                    return Result;
                }
            }
        }
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> enumerable)
        {
            List<Node<T>> AllNodes = new List<Node<T>>();
            // Create tree.
            Node<T> Root = new Node<T>() { IsRoot = true };
            Queue<Node<T>> Queue = new Queue<Node<T>>();
            Queue.Enqueue(Root);
            int CurrentLevel = 0;
            int LevelsToCreate = enumerable.Count();
            while (Queue.Count > 0)
            {
                var CurrentLevelNodes = Queue.ToList();
                Queue.Clear();
                foreach (var LoopNode in CurrentLevelNodes)
                {
                    if (LoopNode.Children.Count == 0)
                    {
                        foreach (var LoopValue in enumerable)
                        {
                            var NewNode = new Node<T>() { Value = LoopValue, Parent = LoopNode };
                            AllNodes.Add(NewNode);
                            LoopNode.Children.Add(NewNode);
                            Queue.Enqueue(NewNode);
                        }
                    }
                }
                CurrentLevel++;
                if (CurrentLevel >= LevelsToCreate)
                {
                    break;
                }
            }
            // Return list of all paths (which are combinations).
            List<List<T>> Result = new List<List<T>>();
            foreach (var LoopNode in AllNodes)
            {
                if (!LoopNode.IsRoot)
                {
                    List<T> Combination = LoopNode.Path.Select(Item => Item.Value).ToList();
                    Result.Add(Combination);
                }
            }
            
            return Result;
        }
    }
