    public class LogfileBuilder
    {
        StreamWriter sW;
        const string file1 = "EventLogging1.txt";
        const string file2 = "EventLogging2.txt";
        FileInfo fInfo;
        // moved this variable out of function to track which file was used during last writing
        string usingFile = null;                  
        public void writeLine(string write)
        {
            fInfo = new FileInfo(file1);
            long s1 = fInfo.Length;
            if (s1 > 300)
            {
                // added below check to delete and re-create the file#1 (of zero bytes)
                if (usingFile == file1)
                    File.Create(file2).Close();
                fInfo = new FileInfo(file2);
                long s2 = fInfo.Length;
                if (s2 > 300)
                {
                    File.Create(file1).Close();
                    usingFile = file1;
                }
                else
                {
                    usingFile = file2;
                }
            }
            else 
                usingFile = file1;
            using (sW = File.AppendText(usingFile))
            {
                sW.WriteLine(write);
            }
        }
    }
