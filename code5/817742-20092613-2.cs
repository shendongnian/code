    public class Program
    {
        private static Random random = new Random();
        public static void Main(string[] args)
        {
            // create massive file
            var random = new Random();
            const int lineCount = 32000000;
            var file = File.CreateText("BigFile.txt");
            for (var i = 0; i < lineCount ; i++)
            {
                file.WriteLine("{0}",i.ToString("D10"));
            }
            file.Close();
            int sizeOfRecord = 12;
            var loadedLines = File.ReadAllBytes("BigFile.txt");
            ShuffleByteArray(loadedLines, lineCount, sizeOfRecord);
            File.WriteAllBytes("BigFile2.txt", loadedLines);
        }
        private static void ShuffleByteArray(byte[] byteArray, int lineCount, int sizeOfRecord)
        {
            var temp = new byte[sizeOfRecord];
            for (int i = lineCount - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                // copy i to temp
                Buffer.BlockCopy(byteArray, sizeOfRecord * i, temp, 0, sizeOfRecord);
                // copy j to i
                Buffer.BlockCopy(byteArray, sizeOfRecord * j, byteArray, sizeOfRecord * i, sizeOfRecord);
                // copy temp to j
                Buffer.BlockCopy(temp, 0, byteArray, sizeOfRecord * j, sizeOfRecord);
            }
        }
    }
