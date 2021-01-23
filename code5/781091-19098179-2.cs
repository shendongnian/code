    public static class RotationHelpers {
        ...
        public static IEnumerable<Point3> RotatePoints(this IEnumerable<Point3> points, int angle) {
            foreach (var point in points)
                yield return point.RotatePoint(angle);
        }
    
        ...
    }
