		private readonly object _lockObj = new object();
        public void nextInstruction()
        {
            //
            // The order in which the cycles are started doesn't really matter,
            // since the way how the AutoResetEvents are being used will ensure
            // correct sequence of outputting results.
            //
			lock (_lockObj)
			{
				Task.Factory.StartNew(fetch);
				Task.Factory.StartNew(decode);
				Task.Factory.StartNew(execute);
				Task.Factory.StartNew(writeBack);
				// 
				// When using lock, InstructionFinishedEvent must
				// be used to ensure that nextInstance() remains
				// in the lock until the instruction finishes.
				//
				InstructionFinishedEvent.WaitOne();
			}
        }
