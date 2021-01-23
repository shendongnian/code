       private void logCopier(string sourceFile, string destinationFile)
        {
            string textLine = String.Empty;
            long offset = 0L;
            while (File.Exists(sourceFile))
            {
                FileStream stream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (new StreamReader(stream))
                {
                    stream.Seek(offset, SeekOrigin.Begin);
                    TextReader reader2 = new StreamReader(stream);
                    while ((textLine = reader2.ReadLine()) != null)
                    {
                        StreamWriter writer = File.AppendText(destinationFile);
                        writer.WriteLine(textLine);
                        writer.Close();
                        offset = stream.Position;
                    }
                    continue;
                }
            }
        }
