    public static void Main(string[] args)
    {
        using (Stream infile1 = File.Open("Foobar.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
        using (Stream infile2 = File.Open("Foobar.avi", FileMode.Open, FileAccess.Read, FileShare.Read))
        using (Stream outfile = File.Open("Out.bin", FileMode.Create, FileAccess.Write, FileShare.None))
        {
            // write lengths
            byte[] file1Len = BitConverter.GetBytes(infile1.Length);
            byte[] file2Len = BitConverter.GetBytes(infile2.Length);
            outfile.Write(file1Len, 0, 8);
            outfile.Write(file2Len, 0, 8);
            // write data
            infile1.CopyTo(outfile);
            infile2.CopyTo(outfile);
        }
        // read file 1
        using (Stream combinedFile = File.Open("out.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            byte[] file1len = new byte[8];
            combinedFile.Read(file1len, 0, 8);
            long lFile1Len = BitConverter.ToInt64(file1len, 0);
            // advance past header
            combinedFile.Position = 16;
            // limit
            var limStream = new LimitedStream(combinedFile, lFile1Len);
            // use the file as normal
            var bmp = System.Drawing.Bitmap.FromStream(limStream);
            bmp.Save(@"C:\drop\demo.jpg");
        }
        // read file 2
        using (Stream combinedFile = File.Open("out.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            byte[] file1len = new byte[8];
            combinedFile.Read(file1len, 0, 8);
            long lFile1Len = BitConverter.ToInt64(file1len, 0);
            byte[] file2len = new byte[8];
            combinedFile.Read(file2len, 0, 8);
            long lFile2Len = BitConverter.ToInt64(file2len, 0);
            // advance past header and first file
            combinedFile.Position = 16 + lFile1Len;
            // limit
            var limStream = new LimitedStream(combinedFile, lFile2Len);
            // copy video out
            var tempPath = System.IO.Path.GetTempFileName();
            using (Stream outStr = File.Open(tempPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                limStream.CopyTo(outStr);
            }
        }
    }
    public class LimitedStream : Stream
    {
        long StartPosition = 0;
        long FunctionalLength = 0;
        long EndPosition { get { return StartPosition + FunctionalLength; } }
        Stream BaseStream = null;
        public LimitedStream(Stream baseStream, long length)
        {
            StartPosition = baseStream.Position;
            FunctionalLength = length;
            BaseStream = baseStream;
        }
        public override bool CanRead
        {
            get { return true; }
        }
        public override bool CanSeek
        {
            get { return BaseStream.CanSeek; }
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void Flush()
        {
            BaseStream.Flush();
        }
        public override long Length
        {
            get { return FunctionalLength; }
        }
        public override long Position
        {
            get
            {
                return BaseStream.Position - StartPosition;
            }
            set
            {
                BaseStream.Position = value + StartPosition;
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (BaseStream.Position + count > EndPosition)
                count = (int)(EndPosition - BaseStream.Position);
            // if there is no more data, return no read
            if (count < 1)
                return 0;
            return BaseStream.Read(buffer, offset, count);
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            if (origin == SeekOrigin.Current)
                return BaseStream.Seek(offset, origin);
            else if (origin == SeekOrigin.Begin)
                return BaseStream.Seek(offset - StartPosition, origin);
            else if (origin == SeekOrigin.End)
                return BaseStream.Seek(BaseStream.Length - EndPosition + offset, origin);
            else throw new NotSupportedException();
        }
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }
    }
