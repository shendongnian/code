        static void OptimizedScan(string fileName)
        {
            const byte startDelimiter = 0x5d;
            const byte endDelimiter = 0x5b;
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                List<byte> buffer = new List<byte>();
                bool captureBytes = false;
                bool foundStartDelimiter = false;
                int wordCount = 0;
                SoapHexBinary hex = new SoapHexBinary();
                while (true)
                {
                    try
                    {
                        byte data = reader.ReadByte();
                        if (data == startDelimiter)
                        {
                            foundStartDelimiter = true;
                        }
                        else if (data == endDelimiter && foundStartDelimiter)
                        {
                            wordCount = DisplayWord(buffer, wordCount, hex);
                            // Start capturing
                            captureBytes = true;
                            foundStartDelimiter = false;
                        }
                        else if (captureBytes)
                        {
                            if (foundStartDelimiter)
                            {
                                buffer.Add(startDelimiter);
                            }
                            buffer.Add(data);
                        }
                    }
                    catch (EndOfStreamException)
                    {
                        break;
                    }
                }
                if (foundStartDelimiter)
                {
                    buffer.Add(startDelimiter);
                }
                DisplayWord(buffer, wordCount, hex);
            }
        }
        private static int DisplayWord(List<byte> buffer, int wordCount, SoapHexBinary hex)
        {
            // Do we have a word in buffer
            if (buffer.Count > 0)
            {
                wordCount++;
                hex.Value = buffer.ToArray();
                Console.WriteLine("Block # {0}: {1}", wordCount, hex.ToString());
                buffer.Clear();
            }
            return wordCount;
        }
