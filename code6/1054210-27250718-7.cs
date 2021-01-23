            int totalTriangles = 0;
            Parallel.ForEach(copy, () => 0,
                             (set, _, __) =>
                             {
                                 int triangles = 0;
                                 if (set.Count > 1)
                                 {
                                     foreach (int neigh1 in set)
                                     {
                                         triangles += set.Count(neigh2 => neigh1 != neigh2 &&
                                                                          copy[neigh1].Contains(neigh2));
                                     }
                                 }
                                 return triangles;
                             },
                             i => Interlocked.Add(ref totalTriangles, i));
