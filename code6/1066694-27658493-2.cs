    // I implement my custom KeyValuePair to serialize (because XmlSerializer can not serialize the .net KeyValuePair)
    public struct CustomKeyValuePair<T1, T2>
    {
        public CustomKeyValuePair(T1 key, T2 value): this()
        {
            Key = key;
            Value = value;
        }
        public T1 Key { get; set; }
        public T2 Value { get; set; }
        // here I specify how is the cast
        public static explicit operator CustomKeyValuePair<T1, T2>(KeyValuePair<T1, T2> keyValuePair)
        {
            return new CustomKeyValuePair<T1, T2>(keyValuePair.Key, keyValuePair.Value);
        }
    }
    // Matrix class used to Serialize with XmlSerailzer
    public class Matrix
    {
        public Matrix() { }  // need a default constructor
        public Matrix(string name, int lines, int columns)
        {
            Name = name;
            Lines = lines;
            Columns = columns;
            Elements = new double[Columns][];
            for (int i = 0; i < Elements.Length; i++)
            {
                Elements[i] = new double[Columns];
            }
        }
        public int Lines { get; set; }
        public int Columns { get; set; }
        public double[][] Elements { get; set; }  // I use double[][] because XmlSerialzer can not serialize a two-dimensional array (double[,])
        public string Name { get; set; }
    }
    public static void Main()
    {
        var path = @"D:\serialize.data"; // use the path that you want
        // this is an example collection
        var listMatrix = new Dictionary<string, Matrix>();
        listMatrix.Add("matrix_1", new Matrix("Matrix 1", 1, 2));
        listMatrix.Add("matrix_2", new Matrix("Matrix 2", 2, 2));
        // Serialization
        var stream = new FileStream(path, FileMode.Create);
        var xmlSerializer = new XmlSerializer(typeof(CustomKeyValuePair<string, Matrix>[]));
        var aux = listMatrix.Select(keyValuePair => (CustomKeyValuePair<string, Matrix>) keyValuePair).ToArray();
        xmlSerializer.Serialize(stream, aux);  // I serialize an array to make easy the deserailizer
        stream.Close();
        // Deserialization
        stream = new FileStream(path, FileMode.Open);
        var result = (CustomKeyValuePair<string, Matrix>[])xmlSerializer.Deserialize(stream);
        stream.Close();
    }
