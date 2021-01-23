        static void OptimizedScan(string fileName)
        {
            const byte endWord = 0x5d;
            const byte startWord = 0x5b;
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                List<byte> buffer = new List<byte>();
                bool captureBytes = false;
                int wordCount = 0;
                SoapHexBinary hex = new SoapHexBinary();
                while (true)
                {
                    try
                    {
                        byte data = reader.ReadByte();
                        if (data == startWord)
                        {
                            // Start capturing
                            captureBytes = true;
                        }
                        else if (data == endWord)
                        {
                            captureBytes = false;
                            // Do we have a word in buffer
                            if (buffer.Count > 0)
                            {
                                wordCount++;
                                hex.Value = buffer.ToArray();
                                Console.WriteLine("Block # {0}: {1}", wordCount, hex.ToString());
                                buffer.Clear();
                            }
                        }
                        else if (captureBytes)
                        {
                            buffer.Add(data);
                        }
                    }
                    catch (EndOfStreamException)
                    {
                        break;
                    }
                }
            }
        }
