    public override int Read(byte[] buffer, int offset, int count)
        {
            while (count > 0)
            {
                //Here you should utilize GZipStream
                Array.Copy(gzipBuffer, position, buffer, offset, count);
            }
            return processedBytes;
        }
