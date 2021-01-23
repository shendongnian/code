    class Program
    {
        static void Main(string[] args)
        {
            using (var s = File.OpenWrite("temp.bin")) {
                var bw = new BinaryWriter(s);
                bw.Write(Encoding.ASCII.GetBytes("HEADER01"));
                bw.Write(Encoding.ASCII.GetBytes("06/17/14"));
                bw.Write(Encoding.ASCII.GetBytes("1.0"));
                bw.Write((byte)0x00);
                bw.Write((byte)0x27);
                bw.Write((byte)0x01);
                bw.Write((byte)0x01);
                bw.Write((byte)0x01);
                bw.Write((byte)0x01);
                bw.Write((byte)0x28);
                bw.Write((byte)192);
                bw.Write((byte)168);
                bw.Write((byte)1);
                bw.Write((byte)1);
            }
        }
    }
