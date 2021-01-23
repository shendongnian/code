    public class JobFile
    {
        public string FullName { get; private set; }
        public string FileName { get; private set; }
        public string Extension { get; private set; }
        public string Path { get; private set; }
        public DateTime Date { get; private set; }
        public long Size { get; private set; }
        public string MD5Hash { get; private set; }
        public void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            StringBuilder hash = new StringBuilder();
            for (int i = 1; (i <= 10); i++)
            {
                // Perform a time consuming operation and report progress.
                // Such as computing part of the hash.
                hash.Append(i);
                //Report progress here
                worker.ReportProgress((i * 10)); // 
            }
            MD5Hash = hash.ToString();
        }
    }
