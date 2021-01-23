	public class Block
	{
		public void Destroy()
		{
			if (_destroyed != null)
			{
				var msg = new BlockDestroyedMessage();
				_destroyed.OnNext(msg);
				_destroyed.OnCompleted();
				_destroyed = null;
			}
		}
		private Subject<BlockDestroyedMessage> _destroyed
			= new Subject<BlockDestroyedMessage>();
			
		public readonly IObservable<BlockDestroyedMessage> Destroyed
			= _destroyed.AsObservable();
	}
