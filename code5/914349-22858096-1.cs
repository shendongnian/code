    using (Stream output = File.OpenWrite(dest))
    {
        foreach (string inputFile in files)
        {
            using (Stream input = File.OpenRead(inputFile))
            {
                byte[] buffer = new byte[16 * 1024];
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                    // report progress back
                    progress = (count / max + read / buffer.Length /* part of this file */) *  100;
                    backgroundWorker2.ReportProgress(Convert.ToInt32(progress));
                }
                count++;
                progress = count * 100 / max;
                backgroundWorker2.ReportProgress(Convert.ToInt32(progress));
            }
        }
    }
