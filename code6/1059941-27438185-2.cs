    namespace ConsoleSlovoMania
    {
        class Program
        {
            public static List<string> paths = new List<string>();
            private static List<string> find_path(int[][] graph, int start, int end, List<string> path = null)
            {
                if (path == null)
                {
                    path = new List<string>();
                }
                path.Add(start.ToString());
                if (start == end)
                {
                    return path;
                }
                foreach (int node in graph[start])
                {
                    if (!path.Contains(node.ToString()))
                    {
                        // before calling recursive step, copy path instead of passing around object reference value
                        List<String> newPath = find_path(graph, node, end, path.ToList());
                        if (newPath != null)
                        {
                            paths.Add(String.Join(",", newPath.ToArray()));
                        }
                    }
                }
                return path = null;
            }
            static void Main()
            {
                int[][] graph = new int[10][];
                graph[1] = new int[] { 2, 4, 5 };
                graph[2] = new int[] { 1, 3, 5, 4, 6 };
                graph[3] = new int[] { 2, 5, 6 };
                graph[4] = new int[] { 1, 2, 7, 8, 5 };
                graph[5] = new int[] { 1, 2, 3, 4, 6, 7, 8 };
                graph[6] = new int[] { 3, 2, 5, 9, 8 };
                graph[7] = new int[] { 4, 5, 8};
                graph[8] = new int[] { 4, 6, 6, 7, 9};
                graph[9] = new int[] { 5, 6, 8 };
    
                for (int i = 1; i <= 9; i++) 
                {
                    for (int j = 1; j <= 9; j++) 
                    {
                        find_path(graph, i, j);
                    }
                }
                Console.ReadKey();
            }
        }
    }
