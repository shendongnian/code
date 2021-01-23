    public class Program
    {
        static void Main()
        {
            FileStream inputStream = File.Open(@"E:\10M.bmp", FileMode.Open);
            const int nblocks = 3;
    
            foreach (byte[] block in inputStream.ReadBlocks(nblocks))
            {
                Console.WriteLine("{0} bytes", block.Length);
            }
        }
    }
