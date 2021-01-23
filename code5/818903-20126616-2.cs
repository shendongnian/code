    using (var sr = new StringReader(fileContents))
    {
        using (var outputStream = GetSomeStreamFromSomewhere())
        {
            char[] buffer = new char[10];
            int numChars;
            while ((numChars = sr.ReadBlock(buffer, 0, buffer.Length)) > 0)
            {
                char[] temp = new char[numChars];
                Array.Copy(buffer, 0, temp, 0, numChars);
                byte[] byteBuffer = Encoding.UTF8.GetBytes(temp);
                outputStream.Write(byteBuffer, 0, byteBuffer.Length);
            }
        }
    }
