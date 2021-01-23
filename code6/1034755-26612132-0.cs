    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        // Basic Node with data and children.
        public sealed class Node
        {
            public string Data;
            public IEnumerable<Node> Children;
        }
        // Encapsulates finding nodes matching a particular predicate.
        public sealed class NodeFinder
        {
            // Maxmimum depth encountered so far while iterating over FindMatchingNodes().
            // The correct value will have been calculated once the FindMatchingNodes() iteration
            // is complete.
            public int MaxDepth
            {
                get
                {
                    return _maxDepth;
                }
            }
            // Finds all the nodes that match a specified predicate.
            public IEnumerable<Node> FindMatchingNodes(Node root, Predicate<string> predicate)
            {
                _maxDepth     = 0;
                _currentDepth = 1;
                return findMatchingNodes(root, predicate);
            }
            // Recursively find all matching nodes.
            private IEnumerable<Node> findMatchingNodes(Node root, Predicate<string> predicate)
            {
                if (predicate(root.Data))
                    yield return root;
                if (root.Children != null)
                {
                    ++_currentDepth;
                    _maxDepth = Math.Max(_currentDepth, _maxDepth);
                    foreach (var child in root.Children.Where(c => c != null))
                        foreach (var matching in findMatchingNodes(child, predicate))
                            yield return matching;
                    --_currentDepth;
                }
            }
            private int _maxDepth;
            private int _currentDepth;
        }
        public static class Program
        {
            private static void Main()
            {
                var root = makeSampleTree();
                NodeFinder nodeFinder = new NodeFinder(); // Use this to find nodes.
                // Print the data for all nodes where 'Data' ends with "0".
                var nodesWithDataEndingIn0 = nodeFinder.FindMatchingNodes(root, data => data.EndsWith("0"));
                foreach (var node in nodesWithDataEndingIn0)
                    Console.WriteLine(node.Data);
                Console.WriteLine("Max depth = " + nodeFinder.MaxDepth);
            }
            private static Node makeSampleTree()
            {
                var root = new Node {Data = "Root"};
                addChildrenTo(root, 4, 0, 5, root.Data);
                return root;
            }
            private static void addChildrenTo(Node node, int numChildren, int depth, int maxDepth, string baseName)
            {
                var newChildren = makeChildren(baseName + ".", numChildren);
                if (depth < maxDepth-1)
                    foreach (var child in newChildren)
                        addChildrenTo(child, numChildren, depth+1, maxDepth, baseName + "." + depth);
                node.Children = newChildren;
            }
            private static Node[] makeChildren(string baseName, int n)
            {
                var result = new Node[n];
                for (int i = 0; i < n; ++i)
                    result[i] = new Node {Data = baseName + i};
                return result;
            }
        }
    }
