        void runReader()
        {
            while (!stopReader)
            {
                var data = ...; // read data from device
                readQueue.Enqueue(data);
            } 
        }
        void runAnalyzer()
        {
            while (!stopAnalyzer)
            {
                Data data;
                if (readQueue.TryDequeue(out data))
                {
                    var result = ...; // analyze data
                    analyzedQueue.Enqueue(result);
                }
                else
                {
                    Thread.Sleep(...); // wait a while
                } 
            }
        }
