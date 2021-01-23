    public static class Extensions
    {
        public static bool InteriorIntersectsWith(this Rect rect, Rect other)
        {
            return rect.IntersectsWith(other) && IsIntersectingInside(rect, other);
        }
        private static bool IsIntersectingInside(Rect rect, Rect other)
        {
            Rect intersectionArea = Rect.Intersect(rect, other);
            return intersectionArea.Width > 0 && intersectionArea.Height > 0;
        }
    }
