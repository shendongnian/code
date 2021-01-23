    public static class FieldCountStatic<T>
    {
        public static int FieldCount { get; set; }
    }
    class Node
    {
        static Node()
        {
            FieldCountStatic<Node>.FieldCount = 3;
        }
        int x, y, z;
    }
    class Way
    {
        static Way()
        {
            FieldCountStatic<Way>.FieldCount = 4;
        }
        int w, x, y, z; // has four fields
    }
    class EnumerableDataReader<TSource> : IDataReader
    {
        public int FieldCount
        {
            get
            {
                return FieldCountStatic<TSource>.FieldCount;
            }
        }
    }
