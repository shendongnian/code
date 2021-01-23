    class EnumerableDataReader<TSource> where TSource : Base
    {
        public int FieldCount
        {
            get {
                return (int)typeof(TSource).GetProperties().Single(x => x.Name == "FieldCount").GetValue(null);
            }
        }
    }
    ...
    var reader = new EnumerableDataReader<Node>();
    Console.WriteLine(reader.FieldCount); // 3
