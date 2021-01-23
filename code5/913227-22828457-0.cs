    namespace DijkstraTest
    {
        class Node
        {
            public Node(int index)
            {
                distanceFromStart = -1;
                this.index = index;
            }
            public int distanceFromStart;
            public bool visited;
            public Node parent;
            public int index;
        }
        class Dijkstra
        {
            private int[,] distanceMatrix;
            private int size;
            public Dijkstra(int[,] distanceMatrix)
            {
                this.distanceMatrix = distanceMatrix;
                size = distanceMatrix.GetLength(0);
                if (distanceMatrix.Rank != 2 || (size != distanceMatrix.GetLength(1)))
                    throw new ArgumentException("Matrix must be 2-D and square!");
            }
            public List<Node> GetShortestPath(int startPos, int endPos)
            {
                var nodes = Enumerable.Range(0, size).Select(i => new Node(i)).ToList();
                nodes[startPos].distanceFromStart = 0;
                var endNode = nodes[endPos];
                while (!endNode.visited)
                {
                    var currentNode = nodes.Where(i => !i.visited && i.distanceFromStart != -1)
                                           .OrderBy(i => i.distanceFromStart).First();
                    foreach (var neighbour in nodes
                                 .Where(i => !i.visited && distanceMatrix[currentNode.index, i.index] != -1))
                             
                    {
                        var thisDistance = currentNode.distanceFromStart +
                                           distanceMatrix[currentNode.index, neighbour.index];
                        if (neighbour.distanceFromStart == -1 || neighbour.distanceFromStart > thisDistance)
                        {
                            neighbour.distanceFromStart = thisDistance;
                            neighbour.parent = currentNode;
                        }
                    }
                    currentNode.visited = true;
                }
                // build the results working back
                var retVal = new List<Node> {endNode};
                while (endNode.parent != null)
                {
                    endNode = endNode.parent;
                    retVal.Add(endNode);
                } 
            
                retVal.Reverse();
                return retVal;
            }
        }
        class Program
        {
            static int[,] DistanceMatrix = {{-1,   24,  15,  27,  19,  16,  11,  33,  28,  30},
                                            {24,  -1,   28,  32,  29,  17,  20,  20,  27,  30},
                                            {15,  28,  -1,   19,  22,  12,  22,  29,  29,  15},
                                            {27,  32,  19,  -1,   29,  23,  13,  31,  20,  28},
                                            {19,  29,  22,  29,  -1,   24,  25,  17,  22,  23},
                                            {16,  17,  12,  23,  24,  -1,   22,  23,  21,  12},
                                            {11,  20,  22,  13,  25,  22,  -1,   28,  23,  19},
                                            {33,  20,  29,  31,  17,  23,  28,  -1,   28,  22},
                                            {28,  27,  29,  20,  22,  21,  23,  28,  -1,   25},
                                            {30,  30,  15,  28,  23,  12,  19,  22,  25,  -1}};
            static void Main(string[] args)
            {
                var dijkstra = new Dijkstra(DistanceMatrix);
                for (int i = 0; i < 10; i++)
                {
                    for (int j = i; j < 10; j++)
                    {
                        var path = dijkstra.GetShortestPath(i, j);
                        // print complex paths that are shorter than just going straight there...
                        if (path.Count > 2)
                        {
                            Console.Write("From {0} to {1}: ", i,j);
                            foreach (var item in path)
                            {
                                Console.Write(" {0} ", item.index);
                            }
                            Console.WriteLine(": Total distance: {0}, Direct distance: {1}", 
                                path.Last().distanceFromStart, DistanceMatrix[i,j]);
                        }
                    }
                }
            }
        }
