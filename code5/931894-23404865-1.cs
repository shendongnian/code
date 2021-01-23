        private void logCopier(string sourceFile, string destinationFile)
        {
            int num = 1;
            string textLine = String.Empty;
            long offset = 0L;
            while (num == 1)
            {
                if (File.Exists(sourceFile))
                {
                    FileStream stream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (new StreamReader(stream))
                    {
                        stream.Seek(offset, SeekOrigin.Begin);
                        TextReader reader2 = new StreamReader(stream);
                        while ((textLine = reader2.ReadLine()) != null)
                        {
                            Thread.Sleep(1);
                            StreamWriter writer = new StreamWriter(destinationFile, true);
                            writer.WriteLine(textLine);
                            writer.Flush();
                            writer.Close();
                            offset = stream.Position;
                        }
                        continue;
                    }
                }
                else
                {
                    num = 0;
                }
            }
        }
