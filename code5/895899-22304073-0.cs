    class Huffman 
    {
        public  int data_size,length,i,is_there, total_nodes;
        string code;
        Huffman(string args) {
            using (var stream = new BinaryReader(System.IO.File.OpenRead(args)))
            {
                while (stream.BaseStream.Position < stream.BaseStream.Length)
                {
                    byte processingValue = stream.ReadByte();
                }
            }
        }
    }
