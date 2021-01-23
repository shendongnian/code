                long lastOffset = 0;
            // this is the first time the file is read
            if (lastOffset == 0)
            {
                using (var fs = new FileStream("myFile.bin", FileMode.Open))
                {
                     lastOffset = fs.Seek(0, SeekOrigin.End);
                }
            }
            else
            {
                using (var fs = new FileStream("myFile.bin", FileMode.Open))
                {
                     lastOffset = fs.Seek(lastOffset, SeekOrigin.Begin);
                }
            }
