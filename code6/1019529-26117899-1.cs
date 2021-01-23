        private void Compress()
        {
            if (sourcePath.EndsWith(".zip"))
            {
                try
                {
                    throw new FileLoadException
                               ("File already compressed. Unzip the file and try again.");
                }
                catch (Exception e)
                {
                    errMsg = e.Message;
                }
            }
        }
