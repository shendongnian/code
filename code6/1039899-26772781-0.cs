    class Program
    {
        static readonly Dictionary<Type, Func<byte[], int, Tuple<object, int>>> _converters =
            new Dictionary<Type, Func<byte[], int, Tuple<object, int>>>
            {
                { typeof(int), (rgb, ib) =>
                    Tuple.Create((object)BitConverter.ToInt32(rgb, ib), sizeof(int)) },
                { typeof(float), (rgb, ib) =>
                    Tuple.Create((object)BitConverter.ToSingle(rgb, ib), sizeof(float)) },
                { typeof(short), (rgb, ib) =>
                    Tuple.Create((object)BitConverter.ToInt16(rgb, ib), sizeof(short)) },
            };
        static void Main(string[] args)
        {
            Type[] typeMap = { typeof(int), typeof(float), typeof(short) };
            byte[] inputBuffer =
                { 0x40, 0xE2, 0x01, 0x00, 0x79, 0xE9, 0xF6, 0x42, 0x39, 0x30 };
            int ib = 0, objectIndex = 0;
            while (ib < inputBuffer.Length)
            {
                Tuple<object, int> current =
                    _converters[typeMap[objectIndex++]](inputBuffer, ib);
                Console.WriteLine("Value: " + current.Item1);
                ib += current.Item2;
            }
        }
    }
