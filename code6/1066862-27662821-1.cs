    public static class ArrayExtensions
    {
       static public T[] Append<T>(this T[] array, T item)
       {
          return array.Concat(new[] { item }).ToArray();
       }
    }
    public static Vertex[] CreateLineStrip(Color color, params Vector2f[] points)
    {
        return CreateVertices(color, points.Append(points[0]));
    }
