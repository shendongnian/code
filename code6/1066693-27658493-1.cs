    [Serializable]  // mark with Serializable
    public class Matrix
    {
        public Matrix(string name, int lines, int columns)
        {
            Name = name;
            Lines = lines;
            Columns = columns;
            Elements = new double[Lines, Columns];
        }
        public int Lines { get; set; }
        public int Columns { get; set; }
        public double[,] Elements { get; set; }
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
        var binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(stream, listMatrix);
        stream.Close();
        // Deserialization
        stream = new FileStream(path, FileMode.Open);
        var result = (Dictionary<string, Matrix>)binaryFormatter.Deserialize(stream);
        stream.Close();
    }
