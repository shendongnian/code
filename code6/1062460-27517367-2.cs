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
                    byte[] chunk = reader.ReadBytes(1024);
                    if (chunk.Length > 0)
                    {
                        foreach (byte data in chunk)
                        {
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
                    }
                    else
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
