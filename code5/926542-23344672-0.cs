  		public Task Close()
		{
			// Close the serial port in a new thread
			Task closeTask = new Task(() => 
			{
				try
				{
					serialPort.Close();
				}
				catch (IOException e)
				{
					// Port was not open
					throw e;
				}
			});
			closeTask.Start();
			return closeTask;
		}
