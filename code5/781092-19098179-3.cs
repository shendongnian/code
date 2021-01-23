    public static class RotationHelpers {
     
        ...
        public static IEnumerable<Point3> ToPoints(this int[,,] matrix) {
            int lx = matrix.GetLength(0);
            int ly = matrix.GetLength(1);
            int lz = matrix.GetLength(2);
            for (int x = 0; x < lx; x++)
            for (int y = 0; y < ly; y++)
            for (int z = 0; z < lz; z++) {
                bool is1 = matrix[x, y, z] != 0;	
                if (is1)
                    yield return new Point3 {
                        X = x - lx / 2,
                        Y = y - ly / 2,
                        Z = z - lz / 2
                    };
            }
        }
        ...
    }
