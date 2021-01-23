	public class Divide
	{
		static int x = 1000;
	
		static ReaderWriterLockSlim locker = new ReaderWriterLockSlim();
	
		public void DivideBy(int divide)
		{
			using(locker.DisposableWriteLock())
			{
				x = x / divide;		
			}
		}
	}
	
	public static class ReaderWriterLockSlimHelper
	{
		public static IDisposable DisposableWriteLock(this ReaderWriterLockSlim readWriteLock)
		{
			readWriteLock.EnterWriteLock();
			return new LockContext(readWriteLock.ExitWriteLock);
		}
		
		private class LockContext : IDisposable
		{
			private Action _disposeContext;
			private bool _isDiposed;
			
			public LockContext(Action diposeContext)
			{
				_disposeContext = disposeContext;
			}
			
			public void Dispose()
			{
				if(_isDiposed)
					return;
				_disposeContext();
				_isDiposed = true;
			}
		}
	}
