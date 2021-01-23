    public enum SwapType
    {
        FrontToBack,
        BackToFront
    }
    public static class EndSwap
    {
        public static void DoSwap(string path, SwapType swapType)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path", 
                    "You must supply a path to the file.");
            }
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found.");
            }
            string tempPath = Path.GetTempFileName();
            byte[] buffer = new byte[4096];
            byte[] swapBytes = new byte[100];
            using (FileStream inputFs = new FileStream(path, FileMode.Open, 
                FileAccess.Read))
            using (FileStream outputFs = new FileStream(tempPath, 
                FileMode.Open, FileAccess.Write))
            {
                int bytesRead = -1;
                if (swapType == SwapType.FrontToBack)
                {
                    // We want to keep hold of the first 100 bytes of the file
                    // and output them after copying the rest of file
                    inputFs.Read(swapBytes, 0, 100);
                }
                else
                {
                    // Read the last 100 bytes of the file
                    inputFs.Seek(-100, SeekOrigin.End);
                    inputFs.Read(swapBytes, 0, 100);
                    // Output them straight to the output file
                    outputFs.Write(swapBytes, 0, 100);
                    // Reposition to the beginning of the input file
                    inputFs.Seek(0, SeekOrigin.Begin);
                }
                // The number of bytes left to copy is 100 less than the file 
                // length
                long bytesRemaining = inputFs.Length - 100;
                // Copy the rest of the bytes
                while (bytesRemaining > 0)
                {
                    bytesRead = inputFs.Read(buffer, 0, buffer.Length);
                    // NB: the number of bytes read could be more than the 
                    // number remaining
                    outputFs.Write(buffer, 0,
                        (int)Math.Min(bytesRead, bytesRemaining));
                    bytesRemaining -= bytesRead;
                }
                // Don't forget to append the start bytes if required
                if (swapType == SwapType.FrontToBack)
                {
                    outputFs.Write(swapBytes, 0, 100);
                }
            }
            // Now swap the files themselves
            File.Delete(path);
            File.Move(tempPath, path);
            // NB: could do File.Replace() if backup is needed
        }
    }
