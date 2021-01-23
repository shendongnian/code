            var copy = new Dictionary<string, HashSet<string>>(Global.dict_edge_undirected);
            int triangles = 0;                          // (number of triangles in graph)*3
            foreach (var pair in copy)
            {
                if (pair.Value.Count > 1)
                {
                    foreach (string neigh1 in pair.Value)
                    {
                        triangles += pair.Value.Count(neigh2 => neigh1 != neigh2 && copy[neigh1].Contains(neigh2));
                    }
                }
            }
