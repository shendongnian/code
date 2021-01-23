    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    double[][,] myJaggedArr = new double[2][,];
    myJaggedArr[0] = new double[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
    myJaggedArr[1] = new double[3, 3] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } };
    var formatter = new BinaryFormatter();
    var stream = new MemoryStream();
    formatter.Serialize(stream, myJaggedArr);
    stream.Position = 0; // Reset the stream.
    var obj = formatter.Deserialize(stream);
