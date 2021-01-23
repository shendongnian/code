            const int N = 100;
            var copy = new HashSet<int>[N];
            int triangles = 0;                          // (number of triangles in graph)*3
            foreach (var pair in copy)
            {
                if (pair.Count > 1)
                {
                    foreach (int neigh1 in pair)
                    {
                        triangles += pair.Count(neigh2 => neigh1 != neigh2 && copy[neigh1].Contains(neigh2));
                    }
                }
            }
