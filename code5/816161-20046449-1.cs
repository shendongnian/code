        public static IEnumerable<T> FindNodeInTree<T>(
                T rootNode, Func<T, bool> predicate, bool firstOnly = false
            ) where T : ObservableTreeNode<K, V>
        {
            var resultNodes = new List<T>();
            var nodeQueue = new Queue<T>();
            nodeQueue.Enqueue(rootNode);
            while (nodeQueue.Any())
            {
                T currentNode = nodeQueue.Dequeue();
                Debug.WriteLine("Current node key: {0}", currentNode.Key);
                if (predicate(currentNode))
                {
                    Debug.WriteLine("Match!");
                    resultNodes.Add(currentNode);
                    if (firstOnly)
                    {
                        Debug.WriteLine("-FindInContext");
                        return resultNodes;
                    }
                }
                Debug.WriteLine("The current node has {0} children.", currentNode.VirtualChildren.Count);
                foreach (T n in currentNode.VirtualChildren)
                {
                    Debug.WriteLine("Enqueue child...");
                    nodeQueue.Enqueue(n);
                }
            }
            return resultNodes;
        }
