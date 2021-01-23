    private MessagePump _messagePump;
	async void OnStart()
	{
		this._messagePump = new MessagePump();
		try
		{
            // make Start method return the task to be able to handle bubbling exception here
			await _messagePump.Start();
		}
		catch (Exception ex)
		{
			// log exception
			// abort service
		}
	}
	void OnStop()
	{
		_messagePump.Stop();
	}
	public enum MessagePumpState
	{
		Running,
		Faulted
	}
	public class MessagePump
	{
		private CancellationTokenSource _cancallationTokenSrc;
		private MessagePumpState _state;
		public async Task Start()
		{
			if (_cancallationTokenSrc != null)
			{
				throw new InvalidOperationException("Task is already running!");
			}
			this._state = MessagePumpState.Running;
			_cancallationTokenSrc = new CancellationTokenSource();
			var task = Task.Factory.StartNew(() => this.ProcessLoop(_cancallationTokenSrc.Token), _cancallationTokenSrc.Token);
			try
			{
				await task;
			}
			catch
			{
				this._state = MessagePumpState.Faulted;
				throw;
			}
		}
		public void Stop()
		{
			if (_cancallationTokenSrc != null)
			{
				_cancallationTokenSrc.Cancel();
				_cancallationTokenSrc = null;
			}
		}
		public void ProcessLoop(CancellationToken token)
		{
            // check if task has been canceled
			while (!token.IsCancellationRequested)
			{
				Console.WriteLine(DateTime.Now);
				Thread.Sleep(1000);
			}
		}
	}
