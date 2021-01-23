    class Program
    {
        static readonly string TestText = "This is a test of the emergency broadcast system.";
        static readonly byte[] TextBytes = Encoding.UTF8.GetBytes(TestText);
        const int Megabyte = 1024 * 1024;
        const int TestBufferSize = 12;
        const int ProducerBufferSize = 4;
        const int ConsumerBufferSize = 5;
        static void Main(string[] args)
        {
            Console.WriteLine("TextBytes contains {0:N0} bytes.", TextBytes.Length);
            using (var pcStream = new ProducerConsumerStream(TestBufferSize))
            {
                Thread ProducerThread = new Thread(ProducerThreadProc);
                Thread ConsumerThread = new Thread(ConsumerThreadProc);
                ProducerThread.Start(pcStream);
                Thread.Sleep(2000);
                ConsumerThread.Start(pcStream);
                ProducerThread.Join();
                ConsumerThread.Join();
            }
            Console.Write("Done. Press Enter.");
            Console.ReadLine();
        }
        static void ProducerThreadProc(object state)
        {
            Console.WriteLine("Producer: started.");
            var pcStream = (ProducerConsumerStream)state;
            int offset = 0;
            while (offset < TestText.Length)
            {
                int bytesToWrite = Math.Min(ProducerBufferSize, TestText.Length - offset);
                pcStream.Write(TextBytes, offset, bytesToWrite);
                offset += bytesToWrite;
            }
            pcStream.CompleteAdding();
            Console.WriteLine("Producer: {0:N0} total bytes written.", offset);
            Console.WriteLine("Producer: exit.");
        }
        static void ConsumerThreadProc(object state)
        {
            Console.WriteLine("Consumer: started.");
            var instream = (ProducerConsumerStream)state;
            int testOffset = 0;
            var inputBuffer = new byte[TextBytes.Length];
            int bytesRead;
            do
            {
                int bytesToRead = Math.Min(ConsumerBufferSize, inputBuffer.Length - testOffset);
                bytesRead = instream.Read(inputBuffer, testOffset, bytesToRead);
                //Console.WriteLine("Consumer: {0:N0} bytes read.", bytesRead);
                testOffset += bytesRead;
            } while (bytesRead != 0);
            Console.WriteLine("Consumer: {0:N0} total bytes read.", testOffset);
            // Compare bytes read with TextBytes
            for (int i = 0; i < TextBytes.Length; ++i)
            {
                if (inputBuffer[i] != TextBytes[i])
                {
                    Console.WriteLine("Read error at position {0}", i);
                    break;
                }
            }
            Console.WriteLine("Consumer: exit.");
        }
    }
