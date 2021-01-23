        class Node
        {
            public double Value { get; set; }
            public Node NextNode { get; set; }
            public Cluster Cluster { get; set; }
        }
        class Cluster : List<Node>
        {
        }
        static void Main()
        {
            double[] values = new double[]
            {
                1.2,
                1.3,
                0.5,
                0.7,
                1.3,
                1.4,
                0.7,
                0.9,
                1.1,
                1.3,
            };
            List<Node> nodes = new List<Node>();
            foreach (double value in values)
            {
                nodes.Add(new Node { Value = value });
            }
            // Put each node in a cluster by itself
            foreach (Node node in nodes)
            {
                node.Cluster = new Cluster();
                node.Cluster.Add(node);
            }
            // Create the cirular Linked List here
            // could probably use System.Collections in some way
            // but using simple self written classes for clarity
            for (int n = 1; n < nodes.Count; n++)
            {
                nodes[n - 1].NextNode = nodes[n];
            }
            nodes[nodes.Count - 1].NextNode = nodes[0];
            // Create a sorted distance list
            List<Node> sortedNodes = new List<Node>(nodes);
            sortedNodes.Sort((a, b) =>
                {
                    var aDistToNext = Math.Abs(a.Value - a.NextNode.Value);
                    var bDistToNext = Math.Abs(b.Value - b.NextNode.Value);
                    return aDistToNext.CompareTo(bDistToNext);
                });
            // Register each node / cluster to the output list
            List<Cluster> clusters = new List<Cluster>();
            foreach (Node node in nodes)
            {
                clusters.Add(node.Cluster);
            }
            // Merge clusters until the desired number is reached
            int distIdx = 0;
            while (clusters.Count > 4)
            {
                // Obtain the two next closest nodes
                var nodeA = sortedNodes[distIdx];
                var nodeB = nodeA.NextNode;
                // Merge the nodes into a single cluster
                nodeA.Cluster.AddRange(nodeB.Cluster);
                // Remove the unnecessary cluster from output set
                clusters.Remove(nodeB.Cluster);
                nodeB.Cluster = nodeA.Cluster;
                distIdx++;
            }
            // Print the output results
            for (int n = 0; n < clusters.Count; n++)
            {
                Console.WriteLine("{0} =>", n);
                foreach (Node node in clusters[n])
                {
                    Console.WriteLine("\t{0}", node.Value);
                }
            }
        }
