    private void waitlUntilFileIsWritable(string fileLocation)
        {
            while (true)
            {
                try
                {
                    using (FileStream Fs = new FileStream(fileLocation, FileMode.Open, FileAccess.ReadWrite, FileShare.None, 100))
                    {
                        //the file is close
                        break;
                    }
                }
                catch (IOException)
                {
                    //wait and retry
                    System.Threading.Thread.Sleep(500);
                }
            }
        }
