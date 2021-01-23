    public class InstructionCycles
    {
        AutoResetEvent DecodeAllowedToOutputEvent = new AutoResetEvent(false);
        AutoResetEvent ExecuteAllowedToOutputEvent = new AutoResetEvent(false);
        AutoResetEvent WriteBackAllowedToOutputEvent = new AutoResetEvent(false);
        // 
        // The InstructionFinishedEvent would not be necessary,
        // if nextInstruction() does not need to wait for the instruction to finish.
        //
        AutoResetEvent InstructionFinishedEvent = new AutoResetEvent(false);
        private void fetch()
        {
            try
            {
                // do something useful...
                // For demo purpose, lets just sleep some arbitrary time
                Thread.Sleep(500);
                // This is the 1st cycle.
                // So we don't need to wait for a previous cycle outputting its result.
                Console.Out.WriteLine("FetchResult");
            }
            finally
            {
                // Allow the next cycle to output its results...
                DecodeAllowedToOutputEvent.Set();
            }
        }
        private void decode()
        {
            try
            {
                // do something useful...
                // For demo purpose, lets just sleep some arbitrary time
                Thread.Sleep(200);
                // Processing done.
                // Now wait to be allowed to output the result.
                DecodeAllowedToOutputEvent.WaitOne();
                Console.Out.WriteLine("DecodeResult");
            }
            finally
            {
                // Allow the next cycle to output its results...
                ExecuteAllowedToOutputEvent.Set();
            }
        }
        private void execute()
        {
            try
            {
                // do something useful...
                // For demo purpose, lets just sleep some arbitrary time
                Thread.Sleep(300);
                // Processing done.
                // Now wait to be allowed to output the result.
                ExecuteAllowedToOutputEvent.WaitOne();
                Console.Out.WriteLine("ExecuteResult");
            }
            finally
            {
                // Allow the next cycle to output its results...
                WriteBackAllowedToOutputEvent.Set();
            }
        }
        private void writeBack()
        {
            try
            {
                // do something useful...
                // For demo purpose, lets just sleep some arbitrary time
                Thread.Sleep(100);
                // Processing done.
                // Now wait to be allowed to output the result.
                WriteBackAllowedToOutputEvent.WaitOne();
                Console.Out.WriteLine("WriteBackResult");
            }
            finally
            {
                // Signal that the instruction (including outputting the result) has finished....
                InstructionFinishedEvent.Set();
            }
        }
        public void nextInstruction()
        {
            //
            // The order in which the cycles are started doesn't really matter,
            // since the way how the AutoResetEvents are being used will ensure
            // correct sequence of outputting results.
            //
            Task.Factory.StartNew(fetch);
            Task.Factory.StartNew(decode);
            Task.Factory.StartNew(execute);
            Task.Factory.StartNew(writeBack);
            // 
            // The InstructionFinishedEvent would not be necessary,
            // if nextInstruction() does not need to wait for the instruction to finish.
            //
            InstructionFinishedEvent.WaitOne();
        }
    }
