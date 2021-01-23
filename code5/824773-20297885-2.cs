    private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        using (FileStream inputFile = new FileStream(strInputFile, FileMode.Open, FileAccess.Read, FileShare.None))
        using (FileStream outputFile = new FileStream(strOutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            long totalBytesToWrite = inputFile.Length;
            long totalBytesWritten = 0;       
            byte[] buffer = new byte[512]; // provide any buffer size here
            int bytesToWrite;
            ushort percentage;
            while ((bytesToWrite = inputFile.Read(buffer, 0, buffer.Length)) > 0)
            {
                outputFile.Write(buffer, 0, bytesToWrite);
                totalBytesWritten += bytesToWrite;
                percentage = (ushort)((100 * totalBytesWritten)/totalBytesToWrite);
                bgWorker.ReportProgress(percentage);
            }
        }
    }
