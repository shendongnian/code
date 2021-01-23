    public static class RotationHelpers {
        ...
        public static void AssignPoints(this int[,,] matrix, IEnumerable<Point3> points) {
            int lx = matrix.GetLength(0);
            int ly = matrix.GetLength(1);
            int lz = matrix.GetLength(2);
            for (int x = 0; x < lx; x++)
            for (int y = 0; y < ly; y++)
            for (int z = 0; z < lz; z++)
                matrix[x, y, z] = 0;
            foreach (var point in points) {
                // this is when quality is lost, because things like 1.7 and 1.71
                // will both become =2
                var x = (int)Math.Round(point.X) + lx / 2;
                var y = (int)Math.Round(point.Y) + ly / 2;
                var z = (int)Math.Round(point.Z) + lz / 2;
                // this is where you loose parts of the object because
                // it doesn't fit anymore inside the parallelepiped
                if ((x >= 0) && (y >= 0) && (z >= 0) &&
                    (x < lx) && (y < ly) && (z < lz))
                    matrix[x, y, z] = 1;
            }
        }
        ...
    }
