    static void Main()
    {
        var nodes = new List<string> { "X", "A", "B", "C", "D", "E" };
        var points = new List<Matrix>
        {
            new Matrix { Origin = "X", Destination = "A", Distance = 2 },
            new Matrix { Origin = "X", Destination = "B", Distance = 12 },
            new Matrix { Origin = "X", Destination = "C", Distance = 7 },
            new Matrix { Origin = "X", Destination = "D", Distance = 19 },
            new Matrix { Origin = "X", Destination = "E", Distance = 16 },
            new Matrix { Origin = "A", Destination = "B", Distance = 10 },
            new Matrix { Origin = "A", Destination = "C", Distance = 8 },
            new Matrix { Origin = "A", Destination = "D", Distance = 15 },
            new Matrix { Origin = "A", Destination = "E", Distance = 17 },
            new Matrix { Origin = "B", Destination = "A", Distance = 10 },
            new Matrix { Origin = "B", Destination = "C", Distance = 11 },
            new Matrix { Origin = "B", Destination = "D", Distance = 18 },
            new Matrix { Origin = "B", Destination = "E", Distance = 21 },
            new Matrix { Origin = "C", Destination = "A", Distance = 8 },
            new Matrix { Origin = "C", Destination = "B", Distance = 11 },
            new Matrix { Origin = "C", Destination = "D", Distance = 7 },
            new Matrix { Origin = "C", Destination = "E", Distance = 9 },
            new Matrix { Origin = "D", Destination = "A", Distance = 15 },
            new Matrix { Origin = "D", Destination = "B", Distance = 18 },
            new Matrix { Origin = "D", Destination = "C", Distance = 7 },
            new Matrix { Origin = "D", Destination = "E", Distance = 5 },
            new Matrix { Origin = "E", Destination = "A", Distance = 17 },
            new Matrix { Origin = "E", Destination = "B", Distance = 21 },
            new Matrix { Origin = "E", Destination = "C", Distance = 9 },
            new Matrix { Origin = "E", Destination = "D", Distance = 5 }
        };
        var sequences = allocateNodes(nodes[0], 
                                      nodes.Count, 
                                      points, 
                                      new Dictionary<int, string>());        
    }
    static Dictionary<int, string> allocateNodes(string current, 
                                                 int nodes, 
                                                 List<Matrix> points, 
                                                 Dictionary<int, string> sequences)
    {
        if (sequences.Count == nodes) return sequences;
        var nextNode = getNextNode(current, points);
        sequences.Add(sequences.Count + 1, nextNode);
        points.RemoveAll(x => x.Origin == current);
        points.RemoveAll(x => x.Destination == current);
        return points.Count == 0 
            ? sequences 
            : allocateNodes(nextNode, nodes, points, sequences);
    }
    static string getNextNode(string origin, IEnumerable<Matrix> points)
    {
        var destinations = points.Where(x => x.Origin == origin);
        var shortestPath = destinations.Min(x => x.Distance);
        var destination = destinations.First(x => x.Distance == shortestPath);
        
        return destination.Destination;
    }
    class Matrix
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Distance { get; set; }
    }
