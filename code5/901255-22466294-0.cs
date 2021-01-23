    class StreamReaderWriterDemo
    {
        public void Run()
        {
            string message = "hello this is a test 0000";
            string result = string.Empty;
            try
            {
                using (var memoryStream = new MemoryStream())
                using (var streamWriter = new StreamWriter(memoryStream, Encoding.Default))
                {
                    WriteToStream(streamWriter, memoryStream, message);
                    memoryStream.Position = 0;
                    var streamReader = new StreamReader(memoryStream, Encoding.Default);
                    result = this.ReadFromStream(streamReader, memoryStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(result);
        }
        private void WriteToStream(StreamWriter streamWriter, MemoryStream stream, string message)
        {
            streamWriter.Write(message);
            streamWriter.Flush();
        }
        private string ReadFromStream(StreamReader streamReader, MemoryStream stream)
        {
            string result;
            result = streamReader.ReadToEnd();
            return result;
        }
    }
