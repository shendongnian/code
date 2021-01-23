    class Program
    {
        static void Main(string[] args)
        {
            var pos = new List<long>();
            using (var writer = new PositionableStreamWriter("tst.txt", false, Encoding.Unicode))
            {
                pos.Add(writer.Position);
                writer.Write("abcde");
                pos.Add(writer.Position);
                writer.WriteLine("Nope");
                pos.Add(writer.Position);
                writer.WriteLine("Something");
                pos.Add(writer.Position);
                writer.WriteLine("Another thing");
                pos.Add(writer.Position);
            }
            using (var stream = File.Open("tst.txt", FileMode.Open))
            using (var reader = new BinaryReader(stream))
            {
                for (int i = 0; i < pos.Count - 1; i++)
                {
                    stream.Position = pos[i];
                    var len = (int)(pos[i + 1] - pos[i]);
                    var buf = reader.ReadBytes(len);
                    Console.Write(Encoding.Unicode.GetString(buf));
                }
            }
        }
    }
