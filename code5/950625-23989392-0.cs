    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = @"H:\Stackoverflow\C#\20140601 - Question 1\Image\DSC_0004b.jpg";
            byte[] blob;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                blob = new byte[fs.Length];
                fs.Read(blob, 0, (int)fs.Length);
            }
            Bitmap bitmap = ByteArrayToBitmap(blob);
            Console.WriteLine("Height = {0}, Width = {1}", bitmap.Height, bitmap.Width);
        }
        protected static Bitmap ByteArrayToBitmap(byte[] blob)
        {
            using (var mStream = new MemoryStream())
            {
                mStream.Write(blob, 0, blob.Length);
                mStream.Position = 0;
                var bm = new Bitmap(mStream);
                return bm;
            }
        }
    }
