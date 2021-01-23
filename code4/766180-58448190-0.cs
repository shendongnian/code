cs
public class ExpiringLazy<T>
{
	private readonly Func<T> factory;
	private readonly TimeSpan lifetime;
	private readonly ReaderWriterLockSlim locking = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
	private T value;
	private DateTime expiresOn = DateTime.MinValue;
	public ExpiringLazy(Func<T> factory, TimeSpan lifetime)
	{
		this.factory = factory;
		this.lifetime = lifetime;
	}
	public T Value
	{
		get
		{
			DateTime now = DateTime.UtcNow;
			locking.EnterUpgradeableReadLock();
			try
			{
				if (expiresOn < now)
				{
					locking.EnterWriteLock();
					try
					{
						if (expiresOn < now)
						{
							value = factory();
							expiresOn = DateTime.UtcNow.Add(lifetime);
						}
					}
					finally
					{
						locking.ExitWriteLock();
					}
				}
				return value;
			}
			finally
			{
				locking.ExitUpgradeableReadLock();
			}
		}
	}
}
