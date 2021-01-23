    public class ConvexHull
    {
        List<Point> points;
        public void run ()
        {
            points.SwapElements(0, 1);
        }
    }
    static class Extensions
    {
        public static void SwapElements<T>(this List<T> list, int index1, int index2)
        {
            T t = list[index1];
            list[index1] = list[index2];
            list[index2] = t;
        }
    }
