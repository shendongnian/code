		public void OnCreate()
		{
			Worker ();
		}
		async void Worker ()
		{
			while (true) {
				await Task.Delay (new TimeSpan (1, 0, 0)).ConfigureAwait (false);
				Console.WriteLine ("Do stuff!");
			}
		}
