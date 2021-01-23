    public Form1()
		{
			InitializeComponent();
		}
		CancellationTokenSource cts;
		private async void button1_Click(object sender, EventArgs e)
		{	
			cts = new CancellationTokenSource();
			int reqNumberOfThreads = int.Parse(textBox1.Text);
			try
			{
				await startSlaves(cts.Token, reqNumberOfThreads);
			}
			catch (OperationCanceledException)
			{
				MessageBox.Show("Canceled Starting Threads");
			}
			cts = null;
		}
		async Task startSlaves(CancellationToken ct, int threadNum)
		{
			List<Task<int>> allTasks = new List<Task<int>>();// ***Add a loop to process the tasks one at a time until none remain. 
			for (int x = 0; x < threadNum; x++)
			{
				allTasks.Add(beginSlaveOperation(ct, x));
			}
			// ***Add a loop to process the tasks one at a time until none remain. 
			while (allTasks.Count <= threadNum)
			{
				// Identify the first task that completes.
				Task<int> output = await Task.WhenAny(allTasks);
				allTasks.Remove(output);
				allTasks.Add(beginSlaveOperation(ct, output.Result));
			}
		}
		public async Task performExampleImportOperationThread(int inputVal, int whoAmI)
		{
			await Task.Delay(inputVal*100);
			System.Console.Write("Thread number" + whoAmI.ToString() + "has finished after "+inputVal.ToString()+" secs \n");
		}
		async Task<int> beginSlaveOperation(CancellationToken ct, int whoAmI)
		{
			Random random = new Random();
			int randomNumber = random.Next(0, 100);//Get command from microSched and remove it from sched
			await performExampleImportOperationThread(randomNumber, whoAmI);//perform operation
			return whoAmI;
		}
		private void button2_Click(object sender, EventArgs e)
		{
			if (cts != null)
			{
				cts.Cancel();
			}
		} 
