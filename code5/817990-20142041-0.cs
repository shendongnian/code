        public AdjacencyGraph<string, Edge<string>> Graph { get; private set; }
        public Dictionary<Edge<string>, double> EdgeCost { get; private set; }
        
        ......
        
        public void FindPath(string @from = "START", string @to = "END")
        {
            Func<Edge<string>, double> edgeCost = AlgorithmExtensions.GetIndexer(EdgeCost);
            // Positive or negative weights
            TryFunc<string, System.Collections.Generic.IEnumerable<Edge<string>>> tryGetPath = Graph.ShortestPathsBellmanFord(edgeCost, @from);
            IEnumerable<Edge<string>> path;
            if (tryGetPath(@to, out path))
            {
                Console.Write("Path found from {0} to {1}: {0}", @from, @to);
                foreach (var e in path) { Console.Write(" > {0}", e.Target); }
                Console.WriteLine();
            }
            else { Console.WriteLine("No path found from {0} to {1}."); }
        }
