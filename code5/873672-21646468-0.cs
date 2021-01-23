    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    
    class Program
    {
        private static void WriteCompressed(string file, byte[] data)
        {
            using (var fileStream = File.Create(file))
            {
                // Write a header saying it should be compressed. There's plenty
                // more you could write here, of course. I've included 1 example.
                BinaryWriter writer = new BinaryWriter(fileStream);
                writer.Write(true); // Compressed
                writer.Write(file); // Example of other data
                using (var deflateStream = new DeflateStream(fileStream,
                    CompressionMode.Compress))
                {
                    deflateStream.Write(data, 0, data.Length);
                }
            }
        }
        
        private static void WriteUncompressed(string file, byte[] data)
        {
            using (var fileStream = File.Create(file))
            {
                // Write a header saying it should be compressed. There's plenty
                // more you could write here, of course.
                BinaryWriter writer = new BinaryWriter(fileStream);
                writer.Write(false); // Not compressed
                writer.Write(file); // Example of other data
                writer.Flush();
                fileStream.Write(data, 0, data.Length);
            }
        }
        
        private static byte[] ReadData(string file)
        {
            using (var fileStream = File.OpenRead(file))
            {
                BinaryReader reader = new BinaryReader(fileStream);
                bool compressed = reader.ReadBoolean();
                reader.ReadString(); // Original filename (ignore for now)
                return ReadStreamFully(compressed
                    ? new DeflateStream(fileStream, CompressionMode.Decompress)
                    : (Stream) fileStream);
            }
        }
        
        private static byte[] ReadStreamFully(Stream stream)
        {
            var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    
        static void Main(string[] args)
        {
            WriteCompressed("foo.dat",
                Encoding.UTF8.GetBytes("This data is compressed"));
            WriteUncompressed("bardat",
                Encoding.UTF8.GetBytes("This data is not compressed"));
            
            Console.WriteLine(Encoding.UTF8.GetString(ReadData("foo.dat")));
            Console.WriteLine(Encoding.UTF8.GetString(ReadData("bar.dat")));
        }    
    }
