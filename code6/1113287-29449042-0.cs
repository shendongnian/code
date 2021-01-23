    public Ray FindShortestDistance(Ray ray1, Ray ray2)
    {
        if (ray1.Position == ray2.Position) // same position - that is the point of intersection
            return new Ray(ray1.Position, Vector3.Zero);
        var d3 = Vector3.Cross(ray1.Direction, ray2.Direction);
        if (d3 != Vector3.Zero) // lines askew (non - parallel)
        {
            //d3 is a cross product of ray1.Direction (d1) and ray2.Direction(d2)
            //    that means d3 is perpendicular to both d1 and d2 (since it's not zero - we checked that)    
            //
            //If we would look at our lines from the direction where they seem parallel 
            //    (such projection must always exist for lines that are askew)
            //    we would see something like this
            //
            //   p1   a*d1
            //   +----------->x------
            //                |
            //                | c*d3
            //       p2  b*d2 v 
            //       +------->x----
            //
            //p1 and p2 are positions ray1.Position and ray2.Position - x marks the points of intersection.
            //    a, b and c are factors we multiply the direction vectors with (d1, d2, d3)
            //
            //From the illustration we can the shortest distance equation
            //    p1 + a*d1 + c*d3 = p2 + b*d2
            //
            //If we rearrange it so we have a b and c on the left:
            //    a*d1 - b*d2 + c*d3 = p2 - p1
            //
            //And since all of the know variables (d1, d2, d3, p2 and p1) have 3 coordinates (x,y,z)
            //    now we have a set of 3 linear equations with 3 variables.
            //   
            //    a * d1.X - b * d2.X + c * d3.X = p2.X - p1.X
            //    a * d1.Y - b * d2.Y + c * d3.Y = p2.Y - p1.Y
            //    a * d1.Z - b * d2.Z + c * d3.Z = p2.Z - p1.Z
            //
            //If we use matrices, it would be
            //    [d1.X  -d2.X  d3.X ]   [ a ]   [p2.X - p1.X]
            //    [d1.Y  -d2.Y  d3.Y ] * [ a ] = [p2.Y - p1.Y]
            //    [d1.Z  -d2.Z  d3.Z ]   [ a ]   [p2.Z - p1.Z]
            //
            //Or in short notation
            //
            //   [d1.X  -d2.X  d3.X | p2.X - p1.X]
            //   [d1.Y  -d2.Y  d3.Y | p2.Y - p1.Y]
            //   [d1.Z  -d2.Z  d3.Z | p2.Z - p1.Z]
            //
            //After Gaussian elimination, the last column will contain values a b and c
            float[] matrix = new float[12];
            matrix[0] = ray1.Direction.X;
            matrix[1] = -ray2.Direction.X;
            matrix[2] = d3.X;
            matrix[3] = ray2.Position.X - ray1.Position.X;
            matrix[4] = ray1.Direction.Y;
            matrix[5] = -ray2.Direction.Y;
            matrix[6] = d3.Y;
            matrix[7] = ray2.Position.Y - ray1.Position.Y;
            matrix[8] = ray1.Direction.Z;
            matrix[9] = -ray2.Direction.Z;
            matrix[10] = d3.Z;
            matrix[11] = ray2.Position.Z - ray1.Position.Z;
            var result = Solve(matrix, 3, 4);
            float a = result[3];
            float b = result[7];
            float c = result[11];
            if (a >= 0 && b >= 0) // normal shortest distance (between positive parts of the ray)
            {
                Vector3 position = ray1.Position + a * ray1.Direction;
                Vector3 direction = d3 * c;
                return new Ray(position, direction);
            }
            //else will fall through below:
            //    the shortest distance was between a negative part of a ray (or both rays)
            //    this means the shortest distance is between one of the ray positions and another ray 
            //    (or between the two positions)
        }
        //We're looking for the distance between a point and a ray, so we use dot products now
        //Projecting the difference between positions (dP) onto the direction vectors will
        //   give us the position of the shortest distance ray.
        //The magnitude of the shortest distance ray is the the difference between its 
        //    position and the other rays position
        ray1.Direction.Normalize(); //needed for dot product - it works with unit vectors
        ray2.Direction.Normalize();
        Vector3 dP = ray2.Position - ray1.Position;
        //shortest distance ray position would be ray1.Position + a2 * ray1.Direction
        //                                     or ray2.Position + b2 * ray2.Direction (if b2 < a2)
        //                                     or just distance between points if both (a and b) < 0
        //if either a or b (but not both) are negative, then the shortest is with the other one
        float a2 = Vector3.Dot(ray1.Direction, dP);
        float b2 = Vector3.Dot(ray2.Direction, -dP);
        if (a2 < 0 && b2 < 0)
            return new Ray(ray1.Position, dP);
        Vector3 p3a = ray1.Position + a2 * ray1.Direction;
        Vector3 d3a = ray2.Position - p3a;
        Vector3 p3b = ray1.Position;
        Vector3 d3b = ray2.Position + b2 * ray2.Direction - p3b;
        if (b2 < 0)
            return new Ray(p3a, d3a);
        if (a2 < 0)
            return new Ray(p3b, d3b);
        if (d3a.Length() <= d3b.Length())
            return new Ray(p3a, d3a);
        return new Ray(p3b, d3b);
    }
    //Solves a set of linear equations using Gaussian elimination
    float[] Solve(float[] matrix, int rows, int cols)
    {
        for (int i = 0; i < cols - 1; i++)
            for (int j = i; j < rows; j++)
                if (matrix[i + j * cols] != 0)
                {
                    if (i != j)
                        for (int k = i; k < cols; k++)
                        {
                            float temp = matrix[k + j * cols];
                            matrix[k + j * cols] = matrix[k + i * cols];
                            matrix[k + i * cols] = temp;
                        }
                    j = i;
                    for (int v = 0; v < rows; v++)
                        if (v == j)
                            continue;
                        else
                        {
                            float factor = matrix[i + v * cols] / matrix[i + j * cols];
                            matrix[i + v * cols] = 0;
                            for (int u = i + 1; u < cols; u++)
                            {
                                matrix[u + v * cols] -= factor * matrix[u + j * cols];
                                matrix[u + j * cols] /= matrix[i + j * cols];
                            }
                            matrix[i + j * cols] = 1;
                        }
                    break;
                }
        return matrix;
    }
