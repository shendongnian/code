        bool play = true; // global keep running flag.
        int m_numberOfSamples = 0;
        // Call this ONCE, at the start of your app.
        void Init()
        {
            // perform any initialization here... maybe allocate queue..
        }
        void udpClient_DataReceived(byte[] bytes)
        {
            audioQueue.Enqueue(bytes); //ConcurrentQueue
            int numberOfSamples = Interlocked.Increment(ref m_numberOfSamples);
            if(numberOfSamples == 1)
            {
                // this is a case of first sample
                // Start a Task with a 1 sec delay
                Task.Factory.StartNew(() =>
                    {
                        Task.Delay(1000);
                        PlayQueue();
                    }, TaskCreationOptions.LongRunning);
            }
        }
        private void PlayQueue()
        {
            // if we are here, there is at least 1 sample already.
            byte[] a;
            int remainingSamples = 0;
            do
            {
                if (audioQueue.TryDequeue(out a))  // check if we succesfull got an array
                {
                    audIn.PlayAudio(a);
                    remainingSamples = Interlocked.Decrement(ref m_numberOfSamples);
                }
            }
            while (play && remainingSamples > 0);
            // we got out either by play = false or remainingSamples == 0
            // if remainingSamples == 0, we will get back here with a different **Task**
            // after a new sample has entered into the queue and again we buffer 1 sec using the Task.Delay
        }
