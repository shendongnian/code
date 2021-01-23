    public class StreamManager
    {
        private static StreamWriter file = null;
        public void NewFile(string filePath)
        {
            this.close();
            file = new StreamWriter(filePath);
        }
        public void WriteToFile(string yourData)
        {
            file.Write(yourData);
        }
        public void close()
        {
            if (file != null /* and if not already been closed*/)
            {
                file.Flush();
                file.Close();
            } 
        }
    }
